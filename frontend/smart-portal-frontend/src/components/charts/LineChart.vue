<template>
  <Line v-if="chartData" :data="chartData" :options="options" />
</template>

<script setup>
import { Line } from 'vue-chartjs'
import {
  Chart as ChartJS, Title, Tooltip, Legend,
  LineElement, PointElement, CategoryScale, LinearScale
} from 'chart.js'

ChartJS.register(Title, Tooltip, Legend, LineElement, PointElement, CategoryScale, LinearScale)

// Accept prop
defineProps({
  chartData: Object
})

const options = {
  responsive: true,
  plugins: {
    title: {
      display: true,
      text: 'User vs Request Overview'
    }
  }
}
</script>
