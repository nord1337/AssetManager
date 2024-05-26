<template>
  <div class="home-view">
    <h1>Мой портфель</h1>
    <div>
      <el-row :gutter="16">
        <el-col :span="8">
          <div class="statistic-card">
            <el-statistic :value="`${mainBalanceStore.totalAssetsValue.toFixed(2)} ₽`">
              <template #title>
                <div style="display: inline-flex; align-items: center">
                  Всего средств
                  <el-tooltip
                    effect="dark"
                    content="Всего средств во всех ваших портфелях."
                    placement="top"
                  >
                    <el-icon style="margin-left: 4px" :size="12">
                      <Warning />
                    </el-icon>
                  </el-tooltip>
                </div>
              </template>
            </el-statistic>
            <div class="statistic-footer">
              <div class="footer-item">
                <span>Больше чем за прошлый год на</span>
                <span class="green">
                  {{ mainBalanceStore.profitPercent.toFixed(2) }}%
                  <el-icon>
                    <CaretTop />
                  </el-icon>
                </span>
              </div>
            </div>
          </div>
        </el-col>
        <el-col :span="8">
          <div class="statistic-card">
            <el-statistic :value="`${mainBalanceStore.profitMoney.toFixed(2)} ₽`">
              <template #title>
                <div style="display: inline-flex; align-items: center">
                  Прибыль
                  <el-tooltip
                    effect="dark"
                    content="Разность текущей стоимости активов со стоимостью их покупки."
                    placement="top"
                  >
                    <el-icon style="margin-left: 4px" :size="12">
                      <Warning />
                    </el-icon>
                  </el-tooltip>
                </div>
              </template>
            </el-statistic>
            <div class="statistic-footer">
              <div class="footer-item">
                <span>Меньше чем за прошлый год на </span>
                <span class="red">
                  12%
                  <el-icon>
                    <CaretBottom />
                  </el-icon>
                </span>
              </div>
            </div>
          </div>
        </el-col>
        <el-col :span="8">
          <div class="statistic-card">
            <el-statistic
              :value="`${mainBalanceStore.profitPercent.toFixed(2)}%`"
              title="Доходность"
            >
              <template #title>
                <div style="display: inline-flex; align-items: center">Доходность</div>
              </template>
            </el-statistic>
            <div class="statistic-footer">
              <div class="footer-item">
                <span class="green">
                  Высокая доходность
                  <el-icon>
                    <CaretTop />
                  </el-icon>
                </span>
              </div>
            </div>
          </div>
        </el-col>
      </el-row>
    </div>
    <el-divider />
    <div>
      <el-row>
        <el-row class="home-view__chart" style="width: fit-content">
          <DoughnutChart ref="doughnutRef" :chartData="testData" :options="options" />
        </el-row>
        <el-row style="width: 75%">
          <el-table key="id" :data="investPortfolioStore.investPortfoliosShort" :border="true">
            <el-table-column label="Название" prop="name" />
            <el-table-column label="Стоимость/Вложено">
              <template #default="props">
                <span> {{ props.row.price.toFixed(2) }} ₽</span>
              </template>
            </el-table-column>
            <el-table-column label="Доход ">
              <template #default="props">
                <span> {{ props.row.profit.toFixed(2) }} ₽</span>
              </template>
            </el-table-column>
            <el-table-column label="Доход %">
              <template #default="props">
                <span> {{ props.row.profitPercent.toFixed(2) }} %</span>
              </template>
            </el-table-column>
            <el-table-column label="Доля в инвестицинном портфеле">
              <template #default="props">
                <span> {{ props.row.shareInTotalPortfolio.toFixed(2) }} %</span>
              </template>
            </el-table-column>
          </el-table>
        </el-row>
      </el-row>
    </div>
  </div>
</template>

<script setup lang="ts">
import { CaretBottom, CaretTop, Warning } from '@element-plus/icons-vue'
import { computed, ref } from 'vue'
import { DoughnutChart, type ExtractComponentData } from 'vue-chart-3'
import { Chart, registerables, type ChartData, type ChartOptions } from 'chart.js'
import { useMainBalanceInfoStore } from '@/stores/mainInfoStore'
import { useInvestPortfolioStore } from '@/stores/investPortfolioStore'

const mainBalanceStore = useMainBalanceInfoStore()
const investPortfolioStore = useInvestPortfolioStore()

Chart.register(...registerables)

const doughnutRef = ref<ExtractComponentData<typeof DoughnutChart>>()
const options = ref<ChartOptions<'doughnut'>>({
  responsive: true,
  plugins: {
    legend: {
      position: 'top'
    },
    title: {
      display: true,
      text: 'Портфели'
    }
  }
})

const testData = computed<ChartData<'doughnut'>>(() => ({
  labels: investPortfolioStore.investPortfoliosShort.map((i) => i.name),
  datasets: [
    {
      data: investPortfolioStore.investPortfoliosShort.map(
        (i) => (i.shareInTotalPortfolio / 100) * 100
      ),
      backgroundColor: ['#77CEFF', '#0079AF', '#123E6B', '#97B0C4', '#A5C8ED']
    }
  ]
}))

const init = async () => {
  await mainBalanceStore.loadBalanceInfo()
  await investPortfolioStore.loadInvestPortfoliosShort()
}

init()
</script>

<style lang="scss">
.home-view {
  &__chart {
    align-self: start !important;
  }

  .el-statistic {
    --el-statistic-content-font-size: 28px;
  }

  .statistic-card {
    height: 100%;
    padding: 20px;
    border-radius: 4px;
    background-color: var(--el-bg-color-overlay);
  }

  .statistic-footer {
    display: flex;
    justify-content: space-between;
    align-items: center;
    flex-wrap: wrap;
    font-size: 12px;
    color: var(--el-text-color-regular);
    margin-top: 16px;
  }

  .statistic-footer .footer-item {
    display: flex;
    justify-content: space-between;
    align-items: center;
  }

  .statistic-footer .footer-item span:last-child {
    display: inline-flex;
    align-items: center;
    margin-left: 4px;
  }

  .green {
    color: var(--el-color-success);
  }
  .red {
    color: var(--el-color-error);
  }
}

.flex-grow {
  flex-grow: 1;
}
</style>
