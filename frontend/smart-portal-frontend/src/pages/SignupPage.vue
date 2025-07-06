<template>
  <div class="center-container">
    <div>
      <h2>Signup</h2>
      <form @submit.prevent="signup">
        <input v-model="username" placeholder="Username" required />
        <input v-model="email" type="email" placeholder="Email" required />
        <input v-model="password" type="password" placeholder="Password" required />
        <button type="submit">Register</button>
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
.center-container {
  display: flex;
  justify-content: center;
  align-items: flex-start; /* Adjusted to flex-start */
  height: 100vh; /* Adjust as needed */
  width: 100vw; /* Adjust as needed */
  margin-top: 50px; /* Adjust as needed */
}
</style>