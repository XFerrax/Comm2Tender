import Form from '~/components/Form/Form'
import FormLabel from '~/components/Control/FormLabel'
import MyDatePicker from '~/components/Control/MyDatePicker'

const mixin = {
  components: {
    Form,
    FormLabel,
    MyDatePicker,
  },
  props: {
    
  },
  data() {
    return {
      currentItem: this.value,
      reset: false,
      formDisableActions: false,
      formCompleted: -1,
    }
  },
  beforeCreate() {
    this.$bus.$on('axios-error', () => {
      this.formDisableActions = false
    })
  },
  beforeDestroy() {
    this.$bus.$off('axios-error')
  },
  watch: {
    visible: {
      handler() {
        this.formDisableActions = false
        if (this.visible && this.value) {
          this.currentItem = this.prepare(this.value)
        } else {
          this.formSetDefault()
        }
      },
      immediate: true,
    },
  },
  methods: {
    prepare(item) {
      return item
    },
    formSetDefault() {
      if (this.defaultItem) {
        this.currentItem = JSON.parse(JSON.stringify(this.defaultItem))
      }
    },
    formClose() {
      this.reset = true
      this.$emit('update:visible', false)
      this.$emit('close')
    },
    formBeforeRequest() {
      this.$emit('before-request')
    },
    formSaved(id, isAdd) {
      this.$emit('saved', id, isAdd)
      this.formClose()
    },
  },
}

export default mixin
