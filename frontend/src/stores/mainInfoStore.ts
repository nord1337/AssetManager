import { ref } from 'vue'
import { defineStore } from 'pinia'
import { getMainBalanceInfo } from '@/components/api'

export const useMainBalanceInfoStore = defineStore('mainBalance', () => {
  const totalAssetsValue = ref<number>(0)
  const profitMoney = ref<number>(0)
  const profitPercent = ref<number>(0)

  const loadBalanceInfo = async () => {
    const response = await getMainBalanceInfo()

    totalAssetsValue.value = response.data.totalAssetsValue
    profitMoney.value = response.data.profitMoney
    profitPercent.value = response.data.profitPercent
  }

  return { totalAssetsValue, profitMoney, profitPercent, loadBalanceInfo }
})
