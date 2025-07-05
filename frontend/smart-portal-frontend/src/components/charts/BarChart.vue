<template>
  <Bar v-if="chartData" :data="chartData" :options="options" />
</template>

<script setup>
import { Bar } from 'vue-chartjs'
import { Chart as ChartJS, Title, Tooltip, Legend, BarElement, CategoryScale, LinearScale } from 'chart.js'

defineProps(['chartData'])

ChartJS.register(Title, Tooltip, Legend, BarElement, CategoryScale, LinearScale)

const options = {
  responsive: true,
  plugins: {
    legend: { position: 'top' },
    title: { display: true, text: 'Logistics Analytics' }
  }
}
</script>
