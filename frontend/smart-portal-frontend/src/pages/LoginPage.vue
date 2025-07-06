<template>
  <div class="center-container">
    <div>
      <h2>Login</h2>
      <form @submit.prevent="login">
        <input v-model="email" type="email" placeholder="Email" required />
        <input v-model="password" type="password" placeholder="Password" required />
        <button type="submit">Login</button>
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
      email: '',
      password: '',
      message: '',
      error: ''
    };
  },
  methods: {
    async login() {
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
          const profileRes = await fetch('http://localhost:5272/api/Auth/profile', {
            headers: { Authorization: 'Bearer ' + data.token }
          });
          const profileData = await profileRes.json();
          const emailMatch = profileData.message?.match(/, (.*?)!/);
          if (emailMatch) {
            localStorage.setItem('userEmail', emailMatch[1]);
          }
          this.message = 'Login successful!';
          this.$router.push('/sourcing');
        } else {
          this.error = data.message || 'Login failed.';
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