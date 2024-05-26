<template>
  <el-dialog
    :model-value="visible"
    title="Добавить портфель"
    width="500"
    center
    @close="handleClose"
  >
    <el-form :model="form">
      <el-form-item label="Название" :label-width="140">
        <el-input v-model="form.title" autocomplete="off" />
      </el-form-item>
      <el-form-item label="О портфеле" :label-width="140">
        <el-input v-model="form.about" autocomplete="off" />
      </el-form-item>
    </el-form>
    <template #footer>
      <div class="dialog-footer">
        <el-button @click="handleClose">Отмена</el-button>
        <el-button type="primary" @click="handleSave"> Сохранить </el-button>
      </div>
    </template>
  </el-dialog>
</template>

<script lang="ts" setup>
import { reactive } from 'vue'
import { type AddPortfolioModalProps, type PortfolioForm } from './types'

defineProps<AddPortfolioModalProps>()
const emits = defineEmits(['update:visible', 'save:modelPortfolio'])

const form = reactive<PortfolioForm>({
  title: '',
  about: ''
})

const handleClose = () => {
  emits('update:visible', false)
}

const handleSave = () => {
  emits('save:modelPortfolio', form)
}
</script>
