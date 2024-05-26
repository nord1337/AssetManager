export type PropsAddAssetModal = {
  visible: boolean
  portfolioId: number
  name: string | null
  price: number | null
}

export type AssetForm = {
  portfolioId: number
  assetType: number
  name: string
  count: number
  price: number
  priceCurrent: number
  buyDate: string
  ticker?: string
}
