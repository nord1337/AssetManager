<template>
  <div class="about-view">
    <div class="row about-view__header">
      <h1>Портфели по категориям</h1>
      <div class="flex-grow" />
      <el-button type="primary" class="about-view__add-portfolio-btn" @click="handleAddPortfolio"
        >Добавить портфель</el-button
      >
    </div>
    <el-collapse v-model="activeName">
      <el-collapse-item
        :key="item.name"
        v-for="item in investPortfolioStore.investPortfolios"
        :title="item.about"
        :name="item.name"
      >
        <template #title>
          <h2>{{ item.name }}</h2>
        </template>
        <div>
          <el-table :data="getTableData(item.id)" style="width: 100%">
            <el-table-column type="expand">
              <template #default="props">
                <div m="4">
                  <h3>По единице актива</h3>
                  <el-table :data="props.row.assets">
                    <el-table-column label="Цена покупки">
                      <template #default="scope"> {{ scope.row.boughtPrice }} ₽ </template>
                    </el-table-column>
                    <el-table-column label="Дата покупки">
                      <template #default="scope">
                        {{ dayjs(scope.row.buyDate).format('DD.MM.YYYY') }}
                      </template>
                    </el-table-column>
                    <el-table-column align="right">
                      <template #default="scope">
                        <el-button
                          :icon="Edit"
                          circle
                          type="primary"
                          size="small"
                          @click="handleEditSingle(scope.$index, scope.row)"
                        />
                        <el-button
                          size="small"
                          type="danger"
                          @click="handleDeleteSingle(scope.$index, scope.row)"
                          :icon="Delete"
                          circle
                        />
                      </template>
                    </el-table-column>
                  </el-table>
                </div>
              </template>
            </el-table-column>

            <el-table-column label="Тип актива" prop="typeName">
              <template #default="scope">
                <el-popover effect="light" trigger="hover" placement="top" width="auto">
                  <template #default>
                    <div v-if="scope.row.type == 0">
                      Акция представляет собой ценную бумагу, подтверждающую право собственности на
                      долю компании, покупая которую инвестор становится совладельцем бизнеса,
                      получая право на часть прибыли и участие в собраниях акционеров для принятия
                      решений по распределению прибыли.
                    </div>
                    <div v-if="scope.row.type == 1">
                      Облигации это долговые ценные бумаги, которые выпускаются государством или
                      компаниями, чтобы получить деньги на развитие бизнеса.
                    </div>
                    <div v-if="scope.row.type == 2">Валюты других стран</div>
                    <div v-if="scope.row.type == 3">Прочие активы для инвестиций</div>
                  </template>
                  <template #reference>
                    <el-tag v-if="scope.row.type == 0" type="primary">{{
                      scope.row.typeName
                    }}</el-tag>
                    <el-tag v-if="scope.row.type == 1" type="success">{{
                      scope.row.typeName
                    }}</el-tag>
                    <el-tag v-if="scope.row.type == 2" type="info">{{ scope.row.typeName }}</el-tag>
                    <el-tag v-if="scope.row.type == 3" type="warning">{{
                      scope.row.typeName
                    }}</el-tag>
                  </template>
                </el-popover>
              </template>
            </el-table-column>
            <el-table-column label="Актив" prop="typeName" width="300px">
              <template #default="scope">
                <el-popover effect="light" trigger="hover" placement="top" width="auto">
                  <template #default>
                    <div v-if="scope.row.type == 0">Тикер: {{ scope.row.ticker }}</div>
                    <div>{{ scope.row.name }}</div>
                    <div v-if="scope.row.logoPath">
                      <img
                        :src="scope.row.logoPath"
                        style="height: 30px; width: 30px; object-fit: contain"
                      />
                    </div>
                  </template>
                  <template #reference>
                    <div>
                      <el-tag>{{ scope.row.name }}</el-tag>
                    </div>
                  </template>
                </el-popover>
              </template>
            </el-table-column>
            <el-table-column label="Кол-во" prop="count" />
            <el-table-column label="Средняя цена">
              <template #default="scope"> {{ scope.row.averagePrice }} ₽ </template>
            </el-table-column>
            <el-table-column label="Вложено">
              <template #default="scope"> {{ scope.row.boughtPriceTotal }} ₽ </template>
            </el-table-column>
            <el-table-column label="Текущая стоимость">
              <template #default="scope"> {{ scope.row.currentPriceTotal }} ₽ </template>
            </el-table-column>
            <el-table-column label="Прибыль">
              <template #default="scope"> {{ scope.row.profit }} ₽ </template>
            </el-table-column>
            <el-table-column label="Доходность">
              <template #default="scope"> {{ scope.row.profitPercent.toFixed(1) }} % </template>
            </el-table-column>
            <el-table-column label="Доля в портфеле %">
              <template #default="scope"> {{ scope.row.shareInPortfolio.toFixed(1) }} % </template>
            </el-table-column>
            <el-table-column align="right">
              <template #default="scope">
                <el-tooltip effect="dark" content="Добавить аналогичный актив" placement="top">
                  <el-button
                    :icon="Plus"
                    circle
                    type="primary"
                    size="small"
                    @click="handleAddSame(scope.$index, scope.row, item.id)"
                  >
                  </el-button>
                </el-tooltip>
              </template>
            </el-table-column>
          </el-table>
        </div>
        <div class="about-view__portfolio-footer">
          <div class="flex-grow" />
          <el-button type="primary" round @click="handleAddAsset(item.id)"
            >Добавить актив</el-button
          >
        </div>
      </el-collapse-item>
    </el-collapse>
  </div>
  <AddPortfolioModal
    :visible="showAddPortfolioModal"
    @update:visible="handleConfirm"
    @confirm="handleConfirm"
    v-on:save:model-portfolio="handleSaveNewPortfolio"
  />
  <AddAssetModal
    :key="`${currentAddPortfolioId}${currentAddPortfolioNameAndPrice.price}`"
    :price="currentAddPortfolioNameAndPrice.price"
    :name="currentAddPortfolioNameAndPrice.name"
    :portfolio-id="currentAddPortfolioId"
    :visible="showAddAssetModal"
    @update:visible="handleConfirmAsset"
    @confirm="handleConfirmAsset"
    v-on:save:model-form="handleSaveNewAsset"
  />
  <EditCurrentAssetModal
    :key="currentEditSingleAssetId"
    :id="currentEditSingleAssetId"
    :name="currentEditSingleNameAndPrice.name"
    :price="currentEditSingleNameAndPrice.price ?? 0"
    :buy-date="currentEditSingleBuyDate"
    :visible="showEditSingleModal"
    @update:visible="handleConfirmEditSingle"
    @confirm="handleConfirmEditSingle"
    v-on:save:model-form="handleEditSingleAsset"
  />
</template>

<script setup lang="ts">
import { computed, ref } from 'vue'
import { Delete, Edit, Plus } from '@element-plus/icons-vue'
import AddPortfolioModal from '@/components/modals/addPortfolioModal/AddPortfolioModal.vue'
import AddAssetModal from '@/components/modals/addAssetModal/AddAssetModal.vue'
import EditCurrentAssetModal from '@/components/modals/editCurrentAssetModal/EditCurrentAssetModal.vue'
import type { PortfolioForm } from '@/components/modals/addPortfolioModal/types'
import type { AssetForm } from '@/components/modals/addAssetModal/types'
import { useInvestPortfolioStore } from '@/stores/investPortfolioStore'
import type { AssetDto, GrouppedAssetDto } from '@/components/api/types'
import dayjs from 'dayjs'
import type { EditAssetForm } from '@/components/modals/editCurrentAssetModal/types'

const investPortfolioStore = useInvestPortfolioStore()

const portfoliosData = computed(() =>
  investPortfolioStore.investPortfolios.map((p) => {
    return {
      id: p.id,
      name: p.name,
      title: p.name,
      text: p.about
    }
  })
)
const activeName = ref(portfoliosData.value[0]?.id ?? 0)

const handleAddSame = (index: number, row: GrouppedAssetDto, portfolioId: number) => {
  currentAddPortfolioNameAndPrice.value.name = row.name
  currentAddPortfolioNameAndPrice.value.price = row.averagePrice
  currentAddPortfolioId.value = portfolioId
  showAddAssetModal.value = true
  console.log(index, row)
}

const showEditSingleModal = ref(false)
const currentEditSingleAssetId = ref(0)
const currentEditSingleNameAndPrice = ref<currentAddPortfolioNameAndPriceType>({
  price: null,
  name: null
})
const currentEditSingleBuyDate = ref('')
const handleEditSingle = (index: number, row: AssetDto) => {
  currentEditSingleAssetId.value = row.id
  currentEditSingleNameAndPrice.value.price = row.boughtPrice
  currentEditSingleBuyDate.value = row.buyDate
  console.log(index, row)
  showEditSingleModal.value = true
}

const handleConfirmEditSingle = () => {
  showEditSingleModal.value = false
}

const handleEditSingleAsset = async (editAsset: EditAssetForm) => {
  await investPortfolioStore.editAsset({
    id: editAsset.id,
    buyDate: editAsset.buyDate,
    price: editAsset.price
  })
  showEditSingleModal.value = false
  currentEditSingleAssetId.value = 0
  currentEditSingleNameAndPrice.value.name = null
  currentEditSingleNameAndPrice.value.price = null
}

const handleDeleteSingle = async (index: number, row: AssetDto) => {
  console.log(index, row)
  await investPortfolioStore.deleteAsset(row.id)
}

const getTableData = (id: number): GrouppedAssetDto[] => {
  const result = investPortfolioStore.investPortfolios.find((y) => y.id === id)!.grouppedAssets

  return result
}

const init = async () => {
  await investPortfolioStore.loadInvestPortfolios()
}

init()

const showAddPortfolioModal = ref(false)
const handleAddPortfolio = () => {
  showAddPortfolioModal.value = true
}
const handleConfirm = () => {
  showAddPortfolioModal.value = false
}

const handleSaveNewPortfolio = async (newPortfolio: PortfolioForm) => {
  await investPortfolioStore.addInvestPortfolio(newPortfolio.title, newPortfolio.about)
  showAddPortfolioModal.value = false
}

// modal add asset
type currentAddPortfolioNameAndPriceType = {
  price: number | null
  name: string | null
}
const currentAddPortfolioId = ref<number>(0)
const currentAddPortfolioNameAndPrice = ref<currentAddPortfolioNameAndPriceType>({
  price: null,
  name: null
})

const showAddAssetModal = ref(false)
const handleAddAsset = (portfolioId: number) => {
  showAddAssetModal.value = true
  currentAddPortfolioId.value = portfolioId
}

const handleConfirmAsset = () => {
  showAddAssetModal.value = false
}

const handleSaveNewAsset = async (newPortfolio: AssetForm) => {
  await investPortfolioStore.addAsset({
    count: newPortfolio.count,
    buyDate: newPortfolio.buyDate,
    name: newPortfolio.name,
    ticker: newPortfolio.ticker,
    type: newPortfolio.assetType,
    investPortfolioId: currentAddPortfolioId.value,
    boughtPrice: newPortfolio.price,
    currentPrice: newPortfolio.priceCurrent
  })
  showAddAssetModal.value = false
  currentAddPortfolioId.value = 0
  currentAddPortfolioNameAndPrice.value.name = null
  currentAddPortfolioNameAndPrice.value.price = null
}
</script>

<style lang="scss">
.about-view {
  &__header {
    width: 100%;
    display: flex;
  }

  &__add-portfolio-btn {
    margin-top: 10px;
  }

  &__portfolio-footer {
    margin-top: 20px;
    width: 100%;
    display: flex;
  }
}
.flex-grow {
  flex-grow: 1;
}
</style>
