export type GetMainInvestPortfolioInfoResponse = {
  totalAssetsValue: number
  profitMoney: number
  profitPercent: number
}

export type GetPortfoliosInfoShortResponse = {
  investPortfoliosDto: InvestPortfolioShortDto[]
}

export type InvestPortfolioShortDto = {
  id: number
  name: string
  price: string
  profit: number
  profitPercent: number
  shareInTotalPortfolio: number
}

export type GetPortfoliosInfoResponse = {
  portfoliosInfo: PortfolioInfoDto[]
}

export type PortfolioInfoDto = {
  id: number
  name: string
  about: string
  grouppedAssets: GrouppedAssetDto[]
}

export type GrouppedAssetDto = {
  type: number
  typeName: string
  ticker: string
  name: string
  count: number
  averagePrice: number
  boughtPriceTotal: number
  currentPriceTotal: number
  profit: number
  profitPercent: number
  shareInPortfolio: number
  logoPath: string
  assets: AssetDto[]
}

export type AssetDto = {
  id: number
  buyDate: string
  boughtPrice: number
}

export type AddAssetCommand = {
  buyDate: string
  name: string
  ticker?: string | null
  type: number
  investPortfolioId: number
  boughtPrice: number
  currentPrice: number
  count: number
}

export type EditSingleAssetCommand = {
  id: number
  buyDate: string
  price: number
}
