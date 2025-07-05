<template>
  <div class="p-4">
    <h2 class="text-xl font-bold mb-4">📊 Analytics Dashboard</h2>

    <div class="grid grid-cols-1 md:grid-cols-2 gap-6">
      <div>
        <h3 class="text-lg font-semibold mb-2">Sourcing Requests</h3>
        <BarChart :chartData="sourcingData" />
      </div>

      <div>
        <h3 class="text-lg font-semibold mb-2">Shipments by Status</h3>
        <PieChart :chartData="shipmentData" />
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue'
import BarChart from './charts/BarChart.vue'
import PieChart from './charts/PieChart.vue'
import axios from 'axios'

const sourcingData = ref(null)
const shipmentData = ref(null)

onMounted(async () => {
  const token = localStorage.getItem('token')
  const config = { headers: { Authorization: `Bearer ${token}` } }

  const sourcingRes = await axios.get('http://localhost:5272/api/Admin/sourcing-summary', config)
  const shipmentRes = await axios.get('http://localhost:5272/api/Admin/shipment-summary', config)

  sourcingData.value = {
    labels: sourcingRes.data.map(r => r.productName),
    datasets: [{
      label: 'Qty Requested',
      data: sourcingRes.data.map(r => r.quantity),
      backgroundColor: '#4f46e5'
    }]
  }

  shipmentData.value = {
    labels: Object.keys(shipmentRes.data),
    datasets: [{
      data: Object.values(shipmentRes.data),
      backgroundColor: ['#f97316', '#10b981', '#3b82f6', '#ef4444']
    }]
  }
})
</script>
