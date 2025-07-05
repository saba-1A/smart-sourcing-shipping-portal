<template>
  <div>
    <h1>Smart Sourcing Portal</h1>
    <nav>
      <router-link to="/signup">Signup</router-link> |
      <router-link to="/login">Login</router-link> |
      <router-link to="/sourcing">Sourcing</router-link> |
      <router-link to="/profile">Profile</router-link> |
      <router-link to="/shipping">Shipping Calculator</router-link> | 
      <router-link to="/tracking">Tracking</router-link>
    </nav>
    <hr />
    <router-view />
  </div>
</template>

<script>
export default {};
</script>

