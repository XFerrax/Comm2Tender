import { ref } from 'vue'
import type { Ref } from 'vue'

interface UseCrudMixin {
  search: Ref<string>,
  loading: Ref<boolean>,
  selected: Ref<any[]>,
  items: Ref<any[]>,
  pagination: Ref<any>,
  total: Ref<number>,
  editedItem: Ref<any>,
  menu: Ref<boolean>,
  isNew: Ref<boolean>,
  isForm: Ref<boolean>,
  isDialogConfirm: Ref<boolean>,
  searchTimeout: Ref<NodeJS.Timeout | undefined>,
  mixinSetCurrent: (item: any, func?: () => void) => void,
  mixinMenuItem: (item: any) => void,
  mixinEditItem: (item: any) => void,
  mixinDeleteItem: (item: any) => void,
  mixinBeforeRequest: () => void,
  mixinAfterRequest: (isStopLoad: boolean) => void,
}

export default function mixinUseCrud(): UseCrudMixin {

  const mixinSetCurrent = function(this: UseCrudMixin, item: any, func?: () => void) {
    this.editedItem = JSON.parse(JSON.stringify(item))
    if (func) {
      func()
    }
  }

  const mixinMenuItem = function(this: UseCrudMixin, item: any): void {
    this.mixinSetCurrent(item)
    this.menu.value = true
  }

  const mixinEditItem = function(this: UseCrudMixin, item: any): void {
    this.isNew.value = false
    this.mixinSetCurrent(item)
    this.isForm.value = true
  }

  const mixinDeleteItem = function(this: UseCrudMixin, item: any): void {
    this.mixinSetCurrent(item)
    this.isDialogConfirm.value = true
  }

  const mixinBeforeRequest = function(this: UseCrudMixin): void {
    clearTimeout(this.searchTimeout.value)
    this.loading.value = true
  }

  const mixinAfterRequest = function (this: UseCrudMixin, isStopLoad: boolean): void {
    this.loading.value = false;
    if (isStopLoad) return;
  }

  return {
    search: ref(''),
    loading: ref(false),
    selected: ref([]),
    items: ref([]),
    pagination: ref({}),
    total: ref(0),
    editedItem: ref({}),
    menu: ref(false),
    isNew: ref(false),
    isForm: ref(false),
    isDialogConfirm: ref(false),
    searchTimeout: ref<NodeJS.Timeout | undefined>(undefined),
    mixinSetCurrent,
    mixinMenuItem,
    mixinEditItem,
    mixinDeleteItem,
    mixinBeforeRequest,
    mixinAfterRequest,
  }
}
