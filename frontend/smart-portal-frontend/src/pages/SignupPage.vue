<template>
  <div class="signup-container">
    <div class="signup-form">
      <h2 class="signup-title">Signup</h2>
      <form @submit.prevent="signup">
        <div class="input-group">
          <input 
            v-model="username" 
            placeholder="Username" 
            required 
            class="signup-input"
          />
        </div>
        <div class="input-group">
          <input 
            v-model="email" 
            type="email" 
            placeholder="Email" 
            required 
            class="signup-input"
          />
        </div>
        <div class="input-group">
          <input 
            v-model="password" 
            type="password" 
            placeholder="Password" 
            required 
            class="signup-input"
          />
        </div>
        <button type="submit" class="signup-button">Register</button>
      </form>
      
      <div v-if="message" class="message success-message">
        {{ message }}
      </div>
      <div v-if="error" class="message error-message">
        {{ error }}
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      username: '',
      email: '',
      password: '',
      message: '',
      error: ''
    };
  },
  methods: {
    async signup() {
      try {
        const res = await fetch('http://localhost:5272/api/Auth/register', {
          method: 'POST',
          headers: { 'Content-Type': 'application/json' },
          body: JSON.stringify({
            id: 0,
            username: this.username,
            email: this.email,
            passwordHash: this.password,
            role: 'user'
          })
        });
        
        // Handle JSON or plain text response
        const contentType = res.headers.get('content-type');
        let data;
        
        if (contentType && contentType.includes('application/json')) {
          data = await res.json();
        } else {
          const text = await res.text(); // fallback to plain text
          data = { message: text };
        }
        
        if (res.ok) {
          this.message = data.message || 'Signup successful!';
          this.error = '';
        } else {
          this.error = data.message || 'Signup failed.';
          this.message = '';
        }
      } catch (err) {
        console.error(err);
        this.error = 'Network error. Please try again.';
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
  --gray: #8C8E975;       /* Light gray */
  --white: #FFFFFF;
  --feature-bg: #FFF0ED;   /* Light peachy feature card background */
  --shadow-color: rgba(0, 0, 0, 0.1);
}

.signup-container {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100vh;
  width: 100vw;
  background-color: var(--light);
  font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
}

.signup-form {
  background-color: var(--white);
  padding: 2rem;
  border-radius: 8px;
  box-shadow: 0 4px 12px var(--shadow-color);
  width: 100%;
  max-width: 400px;
}

.signup-title {
  text-align: center;
  margin-bottom: 1.5rem;
  color: var(--dark);
  font-weight: 600;
}

.input-group {
  margin-bottom: 1rem;
}

.signup-input {
  width: 100%;
  padding: 0.75rem;
  border: 1px solid var(--gray);
  border-radius: 4px;
  font-size: 1rem;
  transition: border-color 0.3s;
}

.signup-input:focus {
  outline: none;
  border-color: var(--primary);
  box-shadow: 0 0 0 2px rgba(255, 127, 110, 0.2);
}

.signup-button {
  width: 100%;
  padding: 0.75rem;
  background-color: var(--primary);
  color: var(--white);
  border: none;
  border-radius: 4px;
  font-size: 1rem;
  cursor: pointer;
  transition: background-color 0.3s;
}

.signup-button:hover {
  background-color: var(--primary-dark);
}

.message {
  margin-top: 1rem;
  padding: 0.75rem;
  border-radius: 4px;
  text-align: center;
}

.success-message {
  background-color: var(--feature-bg);
  color: var(--dark);
  border: 1px solid var(--primary-light);
}

.error-message {
  background-color: var(--feature-bg);
  color: var(--primary-dark);
  border: 1px solid var(--primary-dark);
}
</style>