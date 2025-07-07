<template>
  <div class="center-container">
    <div class="form-container">
      <h2 class="sourcing-heading">Sourcing Request</h2>
      <form @submit.prevent="submitRequest">
        <div class="form-group">
          <label for="productName">Product Name</label>
          <input id="productName" v-model="productName" placeholder="Product Name" required />
        </div>
        <div class="form-group">
          <label for="productLink">Product Link</label>
          <input id="productLink" v-model="productLink" placeholder="Product Link" required />
        </div>
        <div class="form-group">
          <label for="quantity">Quantity</label>
          <input id="quantity" v-model.number="quantity" type="number" placeholder="Quantity" min="1" required />
        </div>
        <div class="form-group">
          <label for="notes">Additional Notes (optional)</label>
          <textarea id="notes" v-model="notes" placeholder="Additional Notes (optional)"></textarea>
        </div>
        <button type="submit" class="submit-button">Submit</button>
      </form>
      <p v-if="message" class="message">{{ message }}</p>
      <p v-if="error" class="error">{{ error }}</p>
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
:root {
  --primary: #FF7F6E;       /* Coral primary color */
  --primary-light: #FF9E8F; /* Lighter coral */
  --primary-dark: #E66B5A;  /* Darker coral for hover states */
  --dark: #4A3F3C;         /* Warm dark brown/gray */
  --light: #FFF5F3;        /* Very light peachy white */
  --gray: #8C9E975;       /* Light gray */
  --white: #FFFFFF;
  --feature-bg: #FFF0ED;   /* Light peachy feature card background */
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
  padding: 10px; /* Further reduced padding */
  border-radius: 8px; /* Further reduced border radius */
  box-shadow: 0 3px 6px var(--shadow-color);
  width: 100%;
  max-width: 400px; /* Further reduced max width */
  text-align: center;
}

.sourcing-heading {
  font-size: 1.5rem; /* Further reduced font size */
  color: var(--primary);
  margin-bottom: 8px; /* Further reduced margin */
  font-family: 'Arial', sans-serif;
  font-weight: bold;
}

.form-group {
  margin-bottom: 8px; /* Further reduced margin */
  text-align: left;
}

label {
  display: block;
  margin-bottom: 4px; /* Further reduced margin */
  color: var(--dark);
  font-weight: bold;
  font-size: 0.8rem; /* Further reduced font size */
}

input, textarea {
  width: 100%;
  padding: 6px; /* Further reduced padding */
  border: 1px solid var(--gray);
  border-radius: 4px; /* Further reduced border radius */
  box-sizing: border-box;
  font-size: 0.8rem; /* Further reduced font size */
  transition: border-color 0.3s;
}

input:focus, textarea:focus {
  outline: none;
  border-color: var(--primary);
}

textarea {
  height: 50px; /* Further reduced height */
  resize: vertical;
}

.submit-button {
  width: 100%;
  padding: 6px; /* Further reduced padding */
  background-color: var(--primary);
  color: var(--white);
  border: none;
  border-radius: 4px; /* Further reduced border radius */
  cursor: pointer;
  font-size: 0.9rem; /* Further reduced font size */
  font-weight: bold;
  transition: background-color 0.3s ease;
}

.submit-button:hover {
  background-color: var(--primary-dark);
}

.message, .error {
  color: var(--primary);
  margin-top: 6px; /* Further reduced margin */
  font-size: 0.8rem; /* Further reduced font size */
}

.error {
  color: #f44336;
}

@media (max-width: 768px) {
  .form-container {
    padding: 10px;
  }
  
  .sourcing-heading {
    font-size: 1.4rem;
  }
}
</style>