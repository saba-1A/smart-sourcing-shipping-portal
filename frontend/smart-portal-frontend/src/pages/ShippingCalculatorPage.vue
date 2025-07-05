<template>
  <div>
    <h2>Shipping Rate Calculator</h2>
    <form @submit.prevent="calculateShipping">
      <input v-model.number="weight" type="number" placeholder="Weight (kg)" required />
      <select v-model="region" required>
        <option disabled value="">Select Region</option>
        <option>North America</option>
        <option>Europe</option>
        <option>Asia</option>
        <option>Australia</option>
      </select>
      <select v-model="method" required>
        <option disabled value="">Select Shipping Method</option>
        <option>Air</option>
        <option>Sea</option>
        <option>Land</option>
      </select>
      <button type="submit">Calculate</button>
    </form>

    <div v-if="result" style="margin-top: 1rem;">
      <p>📦 Estimated Shipping Cost: <strong>₹{{ result.cost }}</strong></p>
    </div>
    <p v-if="error" style="color: red;">{{ error }}</p>
  </div>
</template>

<script>
export default {
  data() {
    return {
      weight: null,
      region: '',
      method: '',
      result: null,
      error: ''
    };
  },
  methods: {
    async calculateShipping() {
      const token = localStorage.getItem('token');
      if (!token) {
        this.error = 'Please log in to calculate shipping.';
        return;
      }

      try {
        const response = await fetch('http://localhost:5272/api/Shipping/calculate', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + token
          },
          body: JSON.stringify({
            weight: this.weight,
            region: this.region,
            method: this.method
          })
        });

        const data = await response.json();

        if (response.ok) {
          this.result = data;
          this.error = '';
        } else {
          this.error = data.message || 'Something went wrong.';
          this.result = null;
        }
      } catch (err) {
        console.error('Shipping error:', err);
        this.error = 'Server error. Please try again.';
        this.result = null;
      }
    }
  }
};
</script>
