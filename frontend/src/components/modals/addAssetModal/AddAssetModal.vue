<template>
  <el-dialog
    :model-value="visible"
    title="Добавить актив"
    width="600px"
    height="800px"
    center
    @close="handleClose"
  >
    <el-form :model="form">
      <el-form-item label="Тип актива" :label-width="140">
        <el-select v-model="form.assetType" placeholder="please select your zone">
          <el-option label="Акция" :value="0" />
          <el-option label="Облигация" :value="1" />
          <el-option label="Валюта" :value="2" />
          <el-option label="Другое" :value="3" /> </el-select
      ></el-form-item>
      <el-form-item v-if="form.assetType == 0" label="Тикер" :label-width="140">
        <el-input v-model="form.ticker" autocomplete="off" />
      </el-form-item>
      <el-form-item label="Название" :label-width="140">
        <el-input v-model="form.name" autocomplete="off" />
      </el-form-item>
      <el-form-item label="Количество" :label-width="140">
        <el-input-number v-model="form.count" :min="1" />
      </el-form-item>
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
      <el-form-item label="Цена текущая" :label-width="140">
        <el-input-number v-model="form.priceCurrent" :min="0" :precision="2" />
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
import { type PropsAddAssetModal, type AssetForm } from './types'

const props = defineProps<PropsAddAssetModal>()
const emits = defineEmits(['update:visible', 'save:modelForm'])

const form = reactive<AssetForm>({
  portfolioId: props.portfolioId,
  assetType: 0,
  name: props.name ?? '',
  count: 1,
  price: props.price ?? 0,
  priceCurrent: 0,
  buyDate: ''
})

const handleClose = () => {
  emits('update:visible', false)
}

const handleSave = () => {
  emits('save:modelForm', form)
}
</script>
