<template>
  <div class="p-6 max-w-4xl mx-auto">
    <h1 class="text-2xl font-bold mb-4">📦 Admin Panel - Manage Shipments</h1>

    <table class="w-full border border-gray-300 text-left">
      <thead class="bg-gray-200">
        <tr>
          <th class="p-2 border">ID</th>
          <th class="p-2 border">Product</th>
          <th class="p-2 border">Tracking #</th>
          <th class="p-2 border">User Email</th>
          <th class="p-2 border">Status</th>
          <th class="p-2 border">Update</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="shipment in shipments" :key="shipment.id" class="hover:bg-gray-50">
          <td class="p-2 border">{{ shipment.id }}</td>
          <td class="p-2 border">{{ shipment.productName }}</td>
          <td class="p-2 border">{{ shipment.trackingNumber }}</td>
          <td class="p-2 border">{{ shipment.userEmail }}</td>
          <td class="p-2 border">{{ shipment.status }}</td>
          <td class="p-2 border">
            <select v-model="shipment.newStatus" class="border p-1">
              <option disabled value="">Select</option>
              <option>Processing</option>
              <option>Shipped</option>
              <option>In Transit</option>
              <option>Customs</option>
              <option>Delivered</option>
            </select>
            <button
              @click="updateStatus(shipment)"
              class="ml-2 px-2 py-1 bg-blue-500 text-white rounded hover:bg-blue-600"
            >
              Update
            </button>
          </td>
        </tr>
      </tbody>
    </table>

    <p v-if="message" class="mt-4 text-green-600">{{ message }}</p>
  </div>
</template>

<script>
export default {
  name: 'AdminPanel',
  data() {
    return {
      shipments: [],
      message: ''
    };
  },
  methods: {
    async fetchShipments() {
      try {
        const token = localStorage.getItem('token');
        const response = await fetch('http://localhost:5272/api/Tracking', {
          headers: { Authorization: `Bearer ${token}` }
        });
        if (!response.ok) throw new Error();
        const data = await response.json();
        this.shipments = data.map(s => ({ ...s, newStatus: '' }));
      } catch (error) {
        console.error('Error fetching shipments:', error);
      }
    },
    async updateStatus(shipment) {
      try {
        const token = localStorage.getItem('token');
        const response = await fetch(`http://localhost:5272/api/Tracking/${shipment.id}`, {
          method: 'PUT',
          headers: {
            'Authorization': `Bearer ${token}`,
            'Content-Type': 'application/json'
          },
          body: JSON.stringify(shipment.newStatus)
        });
        if (!response.ok) throw new Error();
        this.message = `Status updated for shipment ID ${shipment.id}`;
        shipment.status = shipment.newStatus;
        shipment.newStatus = '';
      } catch (error) {
        console.error('Error updating status:', error);
      }
    }
  },
  mounted() {
    this.fetchShipments();
  }
};
</script>

<style scoped>
table {
  border-collapse: collapse;
}
</style>