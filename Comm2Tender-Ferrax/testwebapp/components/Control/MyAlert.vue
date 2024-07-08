<template>
  <VAlert :value="visible" :color="color" :dark="dark" :icon="icon" :outlined="outlined" dense :text="text" class="ma-0 text-left" />
</template>

<script setup lang="ts">
import { defineProps } from 'vue';

const props = defineProps({
  visible: {
    type: Boolean,
    default: true,
  },
  dark: {
    type: Boolean,
    default: false,
  },
  outlined: {
    type: Boolean,
    default: false,
  },
  color: {
    type: String,
    default: 'primary',
  },
  icon: {
    type: String,
    default: undefined,
  },
  text: {
    type: String,
    required: true,
  },
});
</script>