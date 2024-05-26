<template>
  <el-dialog
    :model-value="visible"
    title="Добавить актив"
    width="300px"
    height="400px"
    center
    @close="handleClose"
  >
    <el-form :model="form">
      <el-form-item label="Дата покупки" :label-width="140">
        <el-date-picker
          v-model="form.buyDate"
          type="date"
          placeholder="Pick a day"
          size="default"
        />
      </el-form-item>
      <el-form-item label="Цена покупки" :label-width="140">
        <el-input-number v-model="form.price" :min="0" :precision="2" />
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
import { type PropsEditAssetModal, type EditAssetForm } from './types'

const props = defineProps<PropsEditAssetModal>()
const emits = defineEmits(['update:visible', 'save:modelForm'])

const form = reactive<EditAssetForm>({
  id: props.id,
  price: props.price,
  buyDate: props.buyDate
})

const handleClose = () => {
  emits('update:visible', false)
}

const handleSave = () => {
  emits('save:modelForm', form)
}
</script>
