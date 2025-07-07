<template>
  <div class="login-container">
    <div class="login-form">
      <h2 class="login-title">Login</h2>
      <form @submit.prevent="login">
        <div class="input-group">
          <input 
            v-model="email" 
            type="email" 
            placeholder="Email" 
            required 
            class="login-input"
          />
        </div>
        <div class="input-group">
          <input 
            v-model="password" 
            type="password" 
            placeholder="Password" 
            required 
            class="login-input"
          />
        </div>
        <button type="submit" class="login-button">Login</button>
      </form>
      
      <div v-if="message" class="message success-message">
        {{ message }}
      </div>
      <div v-if="error" class="message error-message">
        {{ error }}
      </div>
      
      <div class="forgot-password">
        <router-link to="/forgot-password">Forgot Password?</router-link>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      email: '',
      password: '',
      message: '',
      error: ''
    };
  },
  methods: {
    async login() {
      this.message = '';
      this.error = '';
      
      if (!this.email || !this.password) {
        this.error = 'Please fill in all fields';
        return;
      }
      
      try {
        const res = await fetch('http://localhost:5272/api/Auth/login', {
          method: 'POST',
          headers: { 'Content-Type': 'application/json' },
          body: JSON.stringify({
            email: this.email,
            passwordHash: this.password
          })
        });
        
        const data = await res.json();
        
        if (res.ok && data.token) {
          localStorage.setItem('token', data.token);
          
          try {
            const profileRes = await fetch('http://localhost:5272/api/Auth/profile', {
              headers: { Authorization: `Bearer ${data.token}` }
            });
            
            const profileData = await profileRes.json();
            
            if (profileRes.ok && profileData.message) {
              const emailMatch = profileData.message?.match(/, (.*?)!$/);
              
              if (emailMatch) {
                localStorage.setItem('userEmail', emailMatch[1]);
              }
              
              this.message = 'Login successful!';
              this.$router.push('/sourcing');
            } else {
              this.error = profileData.message || 'Failed to retrieve profile information';
            }
          } catch (profileErr) {
            this.error = 'Failed to retrieve profile information';
            console.error('Profile fetch error:', profileErr);
          }
        } else {
          this.error = data.message || 'Login failed. Please check your credentials.';
        }
      } catch (err) {
        console.error(err);
        this.error = 'Network error. Please try again later.';
      }
    }
  }
};
</script>

<style>
.login-container {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100vh;
  width: 100vw;
  background-color: #f5f7fa;
  font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
}

.login-form {
  background-color: white;
  padding: 2rem;
  border-radius: 8px;
  box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
  width: 100%;
  max-width: 400px;
}

.login-title {
  text-align: center;
  margin-bottom: 1.5rem;
  color: #2c3e50;
  font-weight: 600;
}

.input-group {
  margin-bottom: 1rem;
}

.login-input {
  width: 100%;
  padding: 0.75rem;
  border: 1px solid #ddd;
  border-radius: 4px;
  font-size: 1rem;
  transition: border-color 0.3s;
}

.login-input:focus {
  outline: none;
  border-color: #3498db;
  box-shadow: 0 0 0 2px rgba(52, 152, 219, 0.2);
}

.login-button {
  width: 100%;
  padding: 0.75rem;
  background-color: #3498db;
  color: white;
  border: none;
  border-radius: 4px;
  font-size: 1rem;
  cursor: pointer;
  transition: background-color 0.3s;
}

.login-button:hover {
  background-color: #2980b9;
}

.message {
  margin-top: 1rem;
  padding: 0.75rem;
  border-radius: 4px;
  text-align: center;
}

.success-message {
  background-color: #d4edda;
  color: #155724;
  border: 1px solid #c3e6cb;
}

.error-message {
  background-color: #f8d7da;
  color: #721c24;
  border: 1px solid #f5c6cb;
}

.forgot-password {
  margin-top: 1rem;
  text-align: center;
}

.forgot-password a {
  color: #3498db;
  text-decoration: none;
}

.forgot-password a:hover {
  text-decoration: underline;
}
</style>