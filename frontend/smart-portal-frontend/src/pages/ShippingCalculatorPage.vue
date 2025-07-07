<template>
  <div class="center-container">
    <div class="form-container" style="margin-top: -50px;">
      <h2 class="sourcing-heading">Shipping Rate Calculator</h2>
      <form @submit.prevent="calculateShipping">
        <div class="form-group">
          <label for="weight">Weight (kg)</label>
          <input 
            id="weight" 
            v-model.number="weight" 
            type="number" 
            placeholder="Weight (kg)" 
            required 
            min="0.1"
            step="0.1"
          />
        </div>
        <div class="form-group">
          <label for="region">Region</label>
          <select id="region" v-model="region" required>
            <option value="">Select Region</option>
            <option>North America</option>
            <option>Europe</option>
            <option>Asia</option>
            <option>Australia</option>
          </select>
        </div>
        <div class="form-group">
          <label for="method">Shipping Method</label>
          <select id="method" v-model="method" required>
            <option disabled value="">Select Shipping Method</option>
            <option>Air</option>
            <option>Sea</option>
            <option>Land</option>
          </select>
        </div>
        <button type="submit" class="submit-button">Calculate</button>
      </form>
      <div v-if="result" class="message" style="margin-top: 10px;">
        <p>📦 Estimated Shipping Cost: <strong>₹{{ result.cost }}</strong></p>
        <div class="additional-info" style="margin-top: 5px; font-size: 0.8rem; color: var(--gray);">
          <p>Estimated delivery time: {{ result.deliveryTime }}</p>
          <p>Carrier: {{ result.carrier }}</p>
        </div>
      </div>
      <p v-if="error" class="error">{{ error }}</p>
    </div>
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
        this.error = 'Please log in to calculate.';
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

<style>
:root {
  --primary: #4A90E2;
  --primary-light: #5DA3F1;
  --primary-dark: #3A70B2;
  --dark: #2C3E50;
  --light: #F8FAFC;
  --gray: #A0AEC0;
  --white: #FFFFFF;
  --feature-bg: #E6F0FF;
  --shadow-color: rgba(0, 0, 0, 0.1);
}
.center-container {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100vh;
  width: 100vw;
  background-color: var(--light);
}
.form-container {
  background-color: var(--white);
  padding: 30px;
  border-radius: 10px;
  box-shadow: 0 5px 15px var(--shadow-color);
  width: 100%;
  max-width: 450px;
  text-align: center;
}
.sourcing-heading {
  font-size: 2.2rem;
  color: var(--primary);
  margin-bottom: 20px;
  font-family: 'Arial', sans-serif;
  font-weight: bold;
}
.form-group {
  margin-bottom: 20px;
  text-align: left;
}
label {
  display: block;
  margin-bottom: 8px;
  color: var(--dark);
  font-weight: bold;
  font-size: 1rem;
}
input,
select {
  width: 100%;
  padding: 12px;
  border: 1px solid var(--gray);
  border-radius: 6px;
  box-sizing: border-box;
  font-size: 1rem;
  transition: border-color 0.3s;
}
input:focus,
select:focus {
  outline: none;
  border-color: var(--primary);
}
.submit-button {
  width: 100%;
  padding: 12px;
  background-color: var(--primary);
  color: var(--white);
  border: none;
  border-radius: 6px;
  cursor: pointer;
  font-size: 1.1rem;
  font-weight: bold;
  transition: background-color 0.3s ease;
  margin-top: 10px;
}
.submit-button:hover {
  background-color: var(--primary-dark);
}
.message {
  color: var(--primary);
  margin-top: 20px;
  font-size: 1rem;
  padding: 15px;
  background-color: var(--feature-bg);
  border-radius: 6px;
  text-align: left;
}
.error {
  color: #f44336;
  margin-top: 20px;
  font-size: 1rem;
  padding: 15px;
  background-color: #ffebee;
  border-radius: 6px;
  text-align: left;
}
.additional-info {
  margin-top: 10px;
  padding-top: 10px;
  border-top: 1px dashed var(--gray);
  font-size: 0.9rem;
}
@media (max-width: 768px) {
  .form-container {
    padding: 25px;
  }
  
  .sourcing-heading {
    font-size: 2rem;
  }
}
</style>