<template>
  <div class="p-6">
    <h1 class="text-2xl font-bold mb-6">📊 Admin Analytics Dashboard</h1>
    
    <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
      <div class="bg-white p-4 rounded-2xl shadow">
        <h2 class="text-lg font-semibold mb-2">Requests Overview</h2>
        <PieChart :chartData="pieChartData" />
      </div>

      <div class="bg-white p-4 rounded-2xl shadow">
        <h2 class="text-lg font-semibold mb-2">Monthly Trends</h2>
        <BarChart :chartData="barChartData" />
      </div>

      <div class="bg-white p-4 rounded-2xl shadow">
        <h2 class="text-lg font-semibold mb-2">User Signups</h2>
        <LineChart :chartData="lineChartData" />
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue'
import PieChart from '../components/charts/PieChart.vue'
import BarChart from '../components/charts/BarChart.vue'
import LineChart from '../components/charts/LineChart.vue'

const pieChartData = ref(null)
const barChartData = ref(null)
const lineChartData = ref(null)

onMounted(async () => {
  const token = localStorage.getItem('token')
  const res = await fetch('http://localhost:5272/api/Analytics/summary', {
    headers: {
      Authorization: `Bearer ${token}`
    }
  })
  const data = await res.json()

  pieChartData.value = {
    labels: ['Pending', 'Shipped', 'Delivered'],
    datasets: [{
      data: [data.pending, data.shipped, data.delivered],
      backgroundColor: ['#FF6384', '#36A2EB', '#FFCE56']
    }]
  }

  barChartData.value = {
    labels: ['Pending', 'Shipped', 'Delivered'],
    datasets: [{
      label: 'Requests',
      data: [data.pending, data.shipped, data.delivered],
      backgroundColor: ['#4BC0C0', '#36A2EB', '#FFCE56']
    }]
  }

  lineChartData.value = {
    labels: ['Users', 'Requests'],
    datasets: [{
      label: 'Growth',
      data: [data.totalUsers, data.totalRequests],
      borderColor: '#42A5F5',
      fill: false,
      tension: 0.3
    }]
  }
})
</script>
