<template>
  <v-dialog v-model="props.isOpen" max-width="400">
    <v-card>
      <v-card-title class="text-h5">Подтверждение</v-card-title>
      <v-card-text>Вы уверены, что хотите удалить?</v-card-text>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn color="primary" text @click="confirmDelete">Да</v-btn>
        <v-btn color="secondary" text @click="cancelDelete">Нет</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script lang="ts" setup>
const props = defineProps({
  isOpen: {
    type: Boolean,
    required: true,
  },
})

const emit = defineEmits(['confirm', 'cancel'])

const confirmDelete = () => {
  emit('confirm');
}
const cancelDelete = () => {
  emit('cancel');
}
</script>
