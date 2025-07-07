<template>
  <div class="p-6">
    <h1 class="text-2xl font-bold mb-6 text-center">📊 Admin Analytics Dashboard</h1>
    
    <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
      <div class="bg-white p-4 rounded-lg shadow">
        <h2 class="text-sm font-semibold mb-2 text-center">Requests Overview</h2>
        <div class="h-48">
          <PieChart :chartData="pieChartData" :options="chartOptions" />
        </div>
      </div>
      <div class="bg-white p-4 rounded-lg shadow">
        <h2 class="text-sm font-semibold mb-2 text-center">Monthly Trends</h2>
        <div class="h-48">
          <BarChart :chartData="barChartData" :options="chartOptions" />
        </div>
      </div>
      <div class="bg-white p-4 rounded-lg shadow">
        <h2 class="text-sm font-semibold mb-2 text-center">User Signups</h2>
        <div class="h-48">
          <LineChart :chartData="lineChartData" :options="chartOptions" />
        </div>
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
const chartOptions = ref({
  responsive: true,
  maintainAspectRatio: false,
  plugins: {
    tooltip: {
      mode: 'index',
      intersect: false,
    },
    legend: {
      position: 'top',
      labels: {
        boxWidth: 12,
        padding: 10,
        font: {
          size: 10
        }
      }
    },
  },
  scales: {
    y: {
      beginAtZero: true,
      ticks: {
        font: {
          size: 10
        }
      }
    },
    x: {
      ticks: {
        font: {
          size: 10
        }
      }
    }
  }
})

onMounted(async () => {
  try {
    const token = localStorage.getItem('token')
    const res = await fetch('http://localhost:5272/api/Analytics/summary', {
      headers: {
        Authorization: `Bearer ${token}`
      }
    })
    
    if (!res.ok) throw new Error('Failed to fetch analytics data')
    
    const data = await res.json()
    
    pieChartData.value = {
      labels: ['Pending', 'Shipped', 'Delivered'],
      datasets: [{
        data: [data.pending, data.shipped, data.delivered],
        backgroundColor: ['#FF6384', '#36A2EB', '#FFCE56'],
        hoverOffset: 4,
        borderWidth: 1
      }]
    }
    
    barChartData.value = {
      labels: ['Pending', 'Shipped', 'Delivered'],
      datasets: [{
        label: 'Requests',
        data: [data.pending, data.shipped, data.delivered],
        backgroundColor: ['#4BC0C0', '#36A2EB', '#FFCE56'],
        hoverOffset: 4,
        borderWidth: 1
      }]
    }
    
    lineChartData.value = {
      labels: ['Users', 'Requests'],
      datasets: [{
        label: 'Growth',
        data: [data.totalUsers, data.totalRequests],
        borderColor: '#42A5F5',
        backgroundColor: 'rgba(66, 165, 245, 0.1)',
        fill: true,
        tension: 0.3,
        pointBackgroundColor: '#42A5F5',
        pointBorderColor: '#fff',
        pointHoverBackgroundColor: '#fff',
        pointHoverBorderColor: '#42A5F5',
        pointRadius: 4,
        pointHoverRadius: 6
      }]
    }
  } catch (error) {
    console.error('Error fetching analytics data:', error)
    // You might want to add error handling UI here
  }
})
</script>

<style scoped>
/* Add any additional styles here */
</style>