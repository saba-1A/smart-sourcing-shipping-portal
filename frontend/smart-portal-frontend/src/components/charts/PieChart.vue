<template>
  <Pie v-if="chartData" :data="chartData" :options="options" />
</template>

<script setup>
import { Pie } from 'vue-chartjs'
import { Chart as ChartJS, Title, Tooltip, Legend, ArcElement } from 'chart.js'

defineProps(['chartData'])

ChartJS.register(Title, Tooltip, Legend, ArcElement)

const options = {
  responsive: true,
  plugins: {
    legend: { position: 'top' },
    title: { display: true, text: 'Package Status Distribution' }
  }
}
</script>
