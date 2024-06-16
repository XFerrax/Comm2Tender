<script setup lang="ts">
import { defineProps, reactive, watch, onBeforeUnmount, ref } from 'vue';
import MyAlert from '~/components/Control/MyAlert.vue';
import DialogComponent from '~/components/Dialog/DialogComponent.vue';

interface Props {
  visible: boolean;
  select: boolean;
  selectMulti: boolean;
  disableAutoLoad: boolean;
  disableFilter: boolean;
  hideFilter: boolean;
  hideSearch: boolean;
  addNow: boolean;
  readonly: boolean;
  actual: boolean;
}

interface MixinData {
  mixinTotal: number;
  mixinItems: any[]; // Adjust type according to your actual data structure
  mixinPagination: Record<string, any>;
  mixinSearch: string;
  mixinFilter: Record<string, any>;
  mixinSearchTimeout: NodeJS.Timeout | null;
  mixinLoading: boolean;
  mixinEditedItem: any | null; // Adjust type according to your actual data structure
  mixinIsNew: boolean;
  mixinForm: boolean;
  mixinMenu: boolean;
  mixinInfo: boolean;
  mixinSelected: any[]; // Adjust type according to your actual data structure
}

const props = defineProps<Props>();
const data = reactive<MixinData>({
  mixinTotal: 0,
  mixinItems: [],
  mixinPagination: {},
  mixinSearch: '',
  mixinFilter: {},
  mixinSearchTimeout: null,
  mixinLoading: false,
  mixinEditedItem: null,
  mixinIsNew: true,
  mixinForm: false,
  mixinMenu: false,
  mixinInfo: false,
  mixinSelected: [],
});

watch(() => data.mixinSearch, (newValue: string) => {
  if (!props.disableAutoLoad) {
    searchWithDelay();
  }
});

watch(() => data.mixinFilter, () => {
  load();
}, { deep: true });

watch(() => data.mixinPagination, () => {
  if (!props.disableAutoLoad) {
    load();
  }
}, { deep: true });

function mixinAdd() {
  emit('update:addNow', false);
  data.mixinIsNew = true;
  mixinSetCurrent(null);
  data.mixinForm = true;
}

function mixinSetCurrent(item: any, func?: Function) {
  data.mixinEditedItem = JSON.parse(JSON.stringify(item));
  if (func) {
    func();
  }
}

function searchWithDelay() {
  if (data.mixinSearchTimeout) {
    clearTimeout(data.mixinSearchTimeout);
  }
  data.mixinSearchTimeout = setTimeout(() => {
    load();
  }, $store.state.searchDelay);
}

onBeforeUnmount(() => {
  $bus.$off('axios-error');
});

$bus.$on('axios-error', () => {
  data.mixinLoading = false;
});
</script>

<script lang="ts">
import { defineComponent } from 'vue';

export default defineComponent({
  // components: {
  //   MyAlert,
  //   DialogComponent,
  // },
  props,
  setup(props, { emit }) {
    return {
      ...toRefs(data),
      mixinAdd,
      mixinSetCurrent,
      // Define other methods to be used in the template
    };
  },
  beforeCreate() {
    $bus.$on('axios-error', () => {
      data.mixinLoading = false;
    });
  },
  beforeDestroy() {
    $bus.$off('axios-error');
  },
});
</script>
