<template>
  <el-menu
    :default-active="activeIndex"
    class="el-menu-demo"
    mode="horizontal"
    :ellipsis="false"
    @select="handleSelect"
  >
    <el-menu-item index="0">
      <RouterLink to="/" style="text-decoration: none">
        <el-icon><Coin /></el-icon>
        <span>Главная</span>
      </RouterLink>
    </el-menu-item>
    <el-menu-item index="1"
      ><RouterLink :to="{ name: 'about' }" style="text-decoration: none"
        >Портфель</RouterLink
      ></el-menu-item
    >
    <div class="flex-grow" />
    <el-sub-menu index="2" v-if="false">
      <template #title>Аккаунт</template>
      <el-menu-item index="2-1">Профиль</el-menu-item>
      <el-menu-item index="2-2">Выйти</el-menu-item>
    </el-sub-menu>
  </el-menu>
</template>

<script setup lang="ts">
import { RouterLink } from 'vue-router'
import { ref } from 'vue'
import { Coin } from '@element-plus/icons-vue'

const activeIndex = ref('0')
const handleSelect = (key: string, keyPath: string[]) => {
  console.log(key, keyPath)
}
</script>

<style scoped>
.flex-grow {
  flex-grow: 1;
}
</style>
