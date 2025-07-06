<template>
  <div class="center-container">
    <div>
      <h2>User Profile</h2>
      <div v-if="error" style="color: red;">{{ error }}</div>
      <div v-else-if="profile">
        <p><strong>Email:</strong> {{ profile.email }}</p>
        <p><strong>Role:</strong> {{ profile.role }}</p>
      </div>
      <div v-else>Loading...</div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      profile: null,
      error: ''
    };
  },
  async mounted() {
    const token = localStorage.getItem('token');
    if (!token) {
      this.error = 'You are not logged in.';
      return;
    }
    try {
      const res = await fetch('http://localhost:5272/api/Auth/profile', {
        headers: {
          Authorization: 'Bearer ' + token
        }
      });
      const data = await res.json();
      if (res.ok && data.message) {
        const match = data.message.match(/back,\s(.*?)!.*role\sis\s(.*?)\./);
        if (match) {
          this.profile = {
            email: match[1],
            role: match[2]
          };
        } else {
          this.error = 'Could not parse profile data.';
        }
      } else {
        this.error = data.message || 'Failed to load profile.';
      }
    } catch (err) {
      console.error(err);
      this.error = 'Network error.';
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