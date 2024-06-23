export default {
  value: {
    type: Object,
    default: null,
  },
  visible: {
    type: String,
    default: '',
  },
  isNew: {
    type: Boolean,
    default: true,
  },
  data: {
    type: String,
    default: '',
  },
  reset: {
    type: Boolean,
    default: false,
  },
  fullscreen: {
    type: Boolean,
    default: false,
  },
  suffix: {
    type: String,
    default: '',
  },
  title: {
    type: String,
    default: null,
  },
  maxWidth: {
    type: String,
    default: '',
  },
  addButtonText: {
    type: String,
    default: null,
  },
  disableSaveButton: {
    type: Boolean,
    default: false,
  },
  disableActions: {
    type: Boolean,
    default: false,
  },
  completed: {
    type: Number,
    default: -1,
  },
  indeterminate: {
    type: Boolean,
    default: true,
  },
}


// export function defaultIProps(): IProps {
//   return {
//     visible: true,
//     select: true,
//     selectMulti: true,
//     disableAutoLoad: true,
//     disableFilter: true,
//     hideFilter: true,
//     hideSearch: true,
//     addNow: true,
//     readonly: true,
//     actual: true,
//   }}


// export function mixinCrud() {
//   interface IProps {
//     visible: boolean;
//     select: boolean;
//     selectMulti: boolean;
//     disableAutoLoad: boolean;
//     disableFilter: boolean;
//     hideFilter: boolean;
//     hideSearch: boolean;
//     addNow: boolean;
//     readonly: boolean;
//     actual: boolean;
//   }
  
//   interface MixinData {
//     mixinTotal: number;
//     mixinItems: any[]; // Adjust type according to your actual data structure
//     mixinPagination: Record<string, any>;
//     mixinSearch: string;
//     mixinFilter: Record<string, any>;
//     mixinSearchTimeout: NodeJS.Timeout | null;
//     mixinLoading: boolean;
//     mixinEditedItem: any | null; // Adjust type according to your actual data structure
//     mixinIsNew: boolean;
//     mixinForm: boolean;
//     mixinMenu: boolean;
//     mixinInfo: boolean;
//     mixinSelected: any[]; // Adjust type according to your actual data structure
//   }

//   const props = defineProps<IProps>()
//   const data = reactive<MixinData>({
//     mixinTotal: 0,
//     mixinItems: [],
//     mixinPagination: {},
//     mixinSearch: '',
//     mixinFilter: {},
//     mixinSearchTimeout: null,
//     mixinLoading: false,
//     mixinEditedItem: null,
//     mixinIsNew: true,
//     mixinForm: false,
//     mixinMenu: false,
//     mixinInfo: false,
//     mixinSelected: [],
//   })

  
// }



// import MyAlert from '~/components/Control/MyAlert.vue';
// import DialogComponent from '~/components/Dialog/DialogComponent.vue';





// watch(() => data.mixinSearch, (newValue: string) => {
//   if (!props.disableAutoLoad) {
//     searchWithDelay();
//   }
// });

// watch(() => data.mixinFilter, () => {
//   load();
// }, { deep: true });

// watch(() => data.mixinPagination, () => {
//   if (!props.disableAutoLoad) {
//     load();
//   }
// }, { deep: true });

// function mixinAdd() {
//   emit('update:addNow', false);
//   data.mixinIsNew = true;
//   mixinSetCurrent(null);
//   data.mixinForm = true;
// }

// function mixinSetCurrent(item: any, func?: Function) {
//   data.mixinEditedItem = JSON.parse(JSON.stringify(item));
//   if (func) {
//     func();
//   }
// }

// function searchWithDelay() {
//   if (data.mixinSearchTimeout) {
//     clearTimeout(data.mixinSearchTimeout);
//   }
//   data.mixinSearchTimeout = setTimeout(() => {
//     load();
//   }, $store.state.searchDelay);
// }

// onBeforeUnmount(() => {
//   $bus.$off('axios-error');
// });

// $bus.$on('axios-error', () => {
//   data.mixinLoading = false;
// });
// </script>

// <script lang="ts">

// export default defineComponent({
//   // components: {
//   //   MyAlert,
//   //   DialogComponent,
//   // },
//   props,
//   setup(props, { emit }) {
//     return {
//       ...toRefs(data),
//       mixinAdd,
//       mixinSetCurrent,
//       // Define other methods to be used in the template
//     };
//   },
//   beforeCreate() {
//     $bus.$on('axios-error', () => {
//       data.mixinLoading = false;
//     });
//   },
//   beforeDestroy() {
//     $bus.$off('axios-error');
//   },
// });