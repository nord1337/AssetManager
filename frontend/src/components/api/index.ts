import axios, { type AxiosPromise } from 'axios'
import type {
  AddAssetCommand,
  EditSingleAssetCommand,
  GetMainInvestPortfolioInfoResponse,
  GetPortfoliosInfoResponse,
  GetPortfoliosInfoShortResponse
} from './types'

export const getMainBalanceInfo = (): AxiosPromise<GetMainInvestPortfolioInfoResponse> =>
  axios.get<GetMainInvestPortfolioInfoResponse>('http://localhost:5210/stocks/mainInfo')

export const getShortInvestPortfolioInfo = (): AxiosPromise<GetPortfoliosInfoShortResponse> =>
  axios.get<GetPortfoliosInfoShortResponse>('http://localhost:5210/stocks/portfoliosInfoShort')

export const getInvestPortfolioInfo = (): AxiosPromise<GetPortfoliosInfoResponse> =>
  axios.get<GetPortfoliosInfoResponse>('http://localhost:5210/stocks/portfoliosInfo')

export const addPortfolio = (portfolioName: string, about: string): AxiosPromise =>
  axios.post('http://localhost:5210/stocks/addPortfolio', {
    porftolioName: portfolioName,
    about: about
  })

export const addAssetAsync = (data: AddAssetCommand): AxiosPromise =>
  axios.post('http://localhost:5210/stocks/addAsset', data)

export const editAssetAsync = (data: EditSingleAssetCommand): AxiosPromise =>
  axios.post('http://localhost:5210/stocks/editAsset', data)

export const deleteAssetAsync = (id: number): AxiosPromise =>
  axios.put('http://localhost:5210/stocks/deleteAsset', {
    id: id
  })
