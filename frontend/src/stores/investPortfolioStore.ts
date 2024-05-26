import { ref } from 'vue'
import { defineStore } from 'pinia'
import {
  addAssetAsync,
  addPortfolio,
  editAssetAsync,
  getInvestPortfolioInfo,
  getShortInvestPortfolioInfo
} from '@/components/api'
import type {
  AddAssetCommand,
  EditSingleAssetCommand,
  InvestPortfolioShortDto,
  PortfolioInfoDto
} from '@/components/api/types'
import { deleteAssetAsync } from '../components/api'

export const useInvestPortfolioStore = defineStore('investPortfolio', () => {
  const investPortfoliosShort = ref<InvestPortfolioShortDto[]>([])
  const investPortfolios = ref<PortfolioInfoDto[]>([])

  const loadInvestPortfoliosShort = async () => {
    const response = await getShortInvestPortfolioInfo()

    investPortfoliosShort.value = response.data.investPortfoliosDto
  }

  const loadInvestPortfolios = async () => {
    const response = await getInvestPortfolioInfo()

    investPortfolios.value = response.data.portfoliosInfo
  }

  const addInvestPortfolio = async (name: string, about: string) => {
    await addPortfolio(name, about)

    await loadInvestPortfolios()
    await loadInvestPortfoliosShort()
  }

  const addAsset = async (data: AddAssetCommand) => {
    await addAssetAsync(data)

    await loadInvestPortfolios()
    await loadInvestPortfoliosShort()
  }

  const editAsset = async (data: EditSingleAssetCommand) => {
    await editAssetAsync(data)

    await loadInvestPortfolios()
    await loadInvestPortfoliosShort()
  }

  const deleteAsset = async (id: number) => {
    await deleteAssetAsync(id)

    await loadInvestPortfolios()
    await loadInvestPortfoliosShort()
  }

  return {
    investPortfoliosShort,
    investPortfolios,
    loadInvestPortfoliosShort,
    loadInvestPortfolios,
    addInvestPortfolio,
    addAsset,
    editAsset,
    deleteAsset
  }
})
