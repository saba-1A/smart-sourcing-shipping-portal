<template>
  <div class="p-4">
    <h1 class="text-3xl font-bold mb-6">Admin Dashboard</h1>

    <div class="grid grid-cols-1 md:grid-cols-2 gap-6">
      <BarChart :chartData="barChartData" />
      <PieChart :chartData="pieChartData" />
      <LineChart :chartData="lineChartData" />
    </div>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue'
import BarChart from '../components/charts/BarChart.vue'
import PieChart from '../components/charts/PieChart.vue'
import LineChart from '../components/charts/LineChart.vue'

const barChartData = ref(null)
const pieChartData = ref(null)
const lineChartData = ref(null)

onMounted(async () => {
  const token = localStorage.getItem('token')
  const res = await fetch('http://localhost:5272/api/Analytics/summary', {
    headers: {
      Authorization: `Bearer ${token}`
    }
  })
  const data = await res.json()

  barChartData.value = {
    labels: ['Pending', 'Shipped', 'Delivered'],
    datasets: [{
      label: 'Requests',
      data: [data.pending, data.shipped, data.delivered],
      backgroundColor: ['#ffcd56', '#36a2eb', '#4bc0c0']
    }]
  }

  pieChartData.value = {
    labels: ['Pending', 'Shipped', 'Delivered'],
    datasets: [{
      label: 'Request Share',
      data: [data.pending, data.shipped, data.delivered],
      backgroundColor: ['#FF6384', '#36A2EB', '#FFCE56']
    }]
  }

  lineChartData.value = {
    labels: ['Total Users', 'Total Requests'],
    datasets: [{
      label: 'Overview',
      data: [data.totalUsers, data.totalRequests],
      borderColor: '#42A5F5',
      tension: 0.3
    }]
  }
})
</script>
