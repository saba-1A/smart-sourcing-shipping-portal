<template>
  <div class="center-container">
    <div>
      <h2>Sourcing Request</h2>
      <form @submit.prevent="submitRequest">
        <input v-model="productName" placeholder="Product Name" />
        <input v-model="productLink" placeholder="Product Link" />
        <input v-model.number="quantity" type="number" placeholder="Quantity" />
        <textarea v-model="notes" placeholder="Additional Notes (optional)"></textarea>
        <button>Submit</button>
      </form>
      <p v-if="message" style="color: green;">{{ message }}</p>
      <p v-if="error" style="color: red;">{{ error }}</p>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      productName: '',
      productLink: '',
      quantity: 1,
      notes: '',
      message: '',
      error: ''
    };
  },
  mounted() {
    const token = localStorage.getItem('token');
    const email = localStorage.getItem('userEmail');
    if (!token || !email) {
      this.error = 'You are not logged in.';
    }
  },
  methods: {
    async submitRequest() {
      const token = localStorage.getItem('token');
      const userEmail = localStorage.getItem('userEmail');
      if (!token || !userEmail) {
        this.error = 'You must be logged in.';
        return;
      }
      const payload = {
        productName: this.productName.trim(),
        productLink: this.productLink.trim(),
        quantity: this.quantity,
        notes: this.notes.trim(),
        userEmail: userEmail
      };
      try {
        const res = await fetch('http://localhost:5272/api/Sourcing', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + token
          },
          body: JSON.stringify(payload)
        });
        const data = await res.json();
        if (res.ok) {
          this.message = data.message || 'Request submitted!';
          this.error = '';
          this.productName = '';
          this.productLink = '';
          this.quantity = 1;
          this.notes = '';
        } else {
          this.error = data.message || 'Failed to submit.';
        }
      } catch (err) {
        console.error(err);
        this.error = 'Network error.';
      }
    }
  }
};
</script>

<style>
.center-container {
  display: flex;
  justify-content: center;
  align-items: flex-start; /* Adjusted to flex-start */
  height: 100vh; /* Adjust as needed */
  width: 100vw; /* Adjust as needed */
  margin-top: 50px; /* Adjust as needed */
}
</style>