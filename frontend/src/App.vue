<template>
  <NavigationComponent />
  <RouterView />
</template>

<script setup lang="ts">
import { RouterView } from 'vue-router'
import NavigationComponent from './components/NavigationComponent.vue'
</script>

<style scoped>
.flex-grow {
  flex-grow: 1;
}
</style>
