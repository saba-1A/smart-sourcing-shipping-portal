<template>
  <div class="container">
    <h2 class="title">📦 Shipment Tracking</h2>

    <div
      v-for="shipment in shipments"
      :key="shipment.id"
      class="card"
    >
      <p><strong>Product:</strong> {{ shipment.productName }}</p>
      <p><strong>Tracking No:</strong> {{ shipment.trackingNumber }}</p>
      <p><strong>Status:</strong> {{ shipment.status }}</p>

      <div v-if="isAdmin">
        <label>Update Status:</label>
        <select v-model="shipment.newStatus">
          <option>Shipped</option>
          <option>In Transit</option>
          <option>Delivered</option>
        </select>
        <button @click="updateStatus(shipment)" :disabled="shipment.sending">
          {{ shipment.sending ? "Sending..." : "Update & Send Email" }}
        </button>
        <p v-if="shipment.emailSent" class="success">✅ Email sent!</p>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      shipments: [],
      token: localStorage.getItem("token"),
      userRole: null
    };
  },
  computed: {
    isAdmin() {
      return this.userRole === "admin";
    }
  },
  methods: {
    async fetchProfile() {
      const res = await fetch("http://localhost:5272/api/Auth/profile", {
        headers: {
          Authorization: `Bearer ${this.token}`
        }
      });
      const data = await res.json();
      this.userRole = data.message?.includes("admin") ? "admin" : "user";
    },

    async fetchShipments() {
      const res = await fetch("http://localhost:5272/api/Tracking", {
        headers: {
          Authorization: `Bearer ${this.token}`
        }
      });
      const data = await res.json();
      this.shipments = data.map(s => ({
        ...s,
        newStatus: s.status,
        emailSent: false,
        sending: false
      }));
    },

    async updateStatus(shipment) {
      shipment.sending = true;
      shipment.emailSent = false;

      const res = await fetch(`http://localhost:5272/api/Tracking/${shipment.id}`, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${this.token}`
        },
        body: JSON.stringify(shipment.newStatus)
      });

      const result = await res.json();

      shipment.emailSent = true;
      shipment.sending = false;
      shipment.status = shipment.newStatus;
    }
  },
  async mounted() {
    await this.fetchProfile();
    await this.fetchShipments();
  }
};
</script>

<style scoped>
.container {
  max-width: 600px;
  margin: 0 auto;
}
.title {
  text-align: center;
  margin-bottom: 20px;
}
.card {
  border: 1px solid #ccc;
  padding: 16px;
  margin-bottom: 15px;
  border-radius: 8px;
  background: #f9f9f9;
}
button {
  margin-top: 8px;
}
.success {
  color: green;
  font-weight: bold;
}
</style>
