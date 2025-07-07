<template>
  <div class="app-container">
    <!-- Header/Navigation -->
    <header class="app-header">
      <div class="container">
        <nav class="navbar">
          <router-link to="/" class="logo">Smart Sourcing Portal</router-link>
          <div class="nav-links">
            <router-link to="/sourcing">Sourcing</router-link>
            <router-link to="/shipping">Shipping Calculator</router-link>
            <router-link to="/tracking">Tracking</router-link>
            <router-link to="/admin-analytics">Analytics</router-link>
            <router-link to="/chatbot">☁️ Chatbot</router-link>
          </div>
          <div class="auth-links">
            <router-link to="/login" class="secondary-button">Login</router-link>
            <router-link to="/signup" class="cta-button">Sign Up</router-link>
          </div>
        </nav>
      </div>
    </header>
    <!-- Main Content -->
    <main>
      <router-view v-slot="{ Component }">
        <transition name="fade" mode="out-in">
          <component :is="Component" />
        </transition>
      </router-view>
      <!-- Default Homepage -->
      <div v-if="$route.path === '/'" class="homepage-content">
        <section class="hero" :style="heroStyle">
          <div class="hero-overlay"></div>
          <div class="container">
            <h1>Smarter Sourcing, Seamless Shipping</h1>
            <p>Manage product sourcing, shipping estimates, and real-time tracking with one sleek portal.</p>
            <div class="hero-buttons">
              <router-link to="/signup" class="cta-button">Get Started Free</router-link>
              <router-link to="/sourcing" class="secondary-button">Explore Features</router-link>
            </div>
          </div>
        </section>
        <section class="features">
          <div class="container">
            <div class="section-title-container">
              <h2 class="section-title">What You Get</h2>
            </div>
            <div class="features-grid">
              <div class="feature-card">
                <div class="feature-icon">📦</div>
                <h3 class="feature-title">Smart Sourcing</h3>
                <p>Find the best suppliers and products with our intelligent sourcing tools.</p>
              </div>
              <div class="feature-card">
                <div class="feature-icon">✈️</div>
                <h3 class="feature-title">Shipping Calculator</h3>
                <p>Accurately estimate shipping costs before placing your orders.</p>
              </div>
              <div class="feature-card">
                <div class="feature-icon">📡</div>
                <h3 class="feature-title">Live Tracking</h3>
                <p>Monitor all your shipments in one place with real-time updates.</p>
              </div>
            </div>
          </div>
        </section>
        <section class="cta-section">
          <div class="container">
            <h2 class="cta-title">Ready to optimize your sourcing workflow?</h2>
            <p>Join hundreds of businesses who are saving time and money with our platform.</p>
            <router-link to="/signup" class="white-button">Start Free Trial</router-link>
          </div>
        </section>
      </div>
    </main>
    <!-- Footer -->
    <footer class="app-footer">
      <div class="container">
        <div class="footer-grid">
          <div class="footer-about">
            <router-link to="/" class="footer-logo">Smart Sourcing</router-link>
            <p>Your complete solution for product sourcing and logistics management.</p>
            <div class="social-links">
              <a href="#"><i class="fab fa-twitter"></i></a>
              <a href="#"><i class="fab fa-facebook"></i></a>
              <a href="#"><i class="fab fa-linkedin"></i></a>
            </div>
          </div>
          <div class="footer-links">
            <h3>Navigation</h3>
            <ul>
              <li><router-link to="/sourcing">Sourcing</router-link></li>
              <li><router-link to="/shipping">Shipping Calculator</router-link></li>
              <li><router-link to="/tracking">Tracking</router-link></li>
              <li><router-link to="/admin-analytics">Analytics</router-link></li>
            </ul>
          </div>
          <div class="footer-links">
            <h3>Company</h3>
            <ul>
              <li><router-link to="/about">About Us</router-link></li>
              <li><router-link to="/blog">Blog</router-link></li>
              <li><router-link to="/contact">Contact</router-link></li>
              <li><router-link to="/terms">Terms</router-link></li>
            </ul>
          </div>
          <div class="footer-links">
            <h3>Support</h3>
            <ul>
              <li><router-link to="/help">Help Center</router-link></li>
              <li><router-link to="/faq">FAQ</router-link></li>
              <li><router-link to="/chatbot">Chatbot</router-link></li>
              <li><router-link to="/feedback">Feedback</router-link></li>
            </ul>
          </div>
        </div>
        <div class="copyright">
          <p>&copy; 2025 Smart Sourcing Portal. All rights reserved.</p>
        </div>
      </div>
    </footer>
  </div>
</template>
<script>
export default {
  name: 'App',
  data() {
    return {
      heroImage: 'https://images.unsplash.com/photo-1556740738-b6a63e27c4df?ixlib=rb-4.0.3&auto=format&fit=crop&w=1920&q=80'
    }
  },
  computed: {
    heroStyle() {
      return {
        backgroundImage: `url(${this.heroImage})`,
        backgroundSize: 'cover',
        backgroundPosition: 'center'
      }
    }
  }
}
</script>
<style>
@import url('https://fonts.googleapis.com/css2?family=Poppins:wght@400;600;700&family=Montserrat:wght@400;700&display=swap');
@import url('https://fonts.googleapis.com/css2?family=Playfair+Display:wght@700&display=swap');
:root {
  --primary: #5C67F2;
  --cream: #FFF8E1;
  --accent: #FFC857;
  --dark: #2D2A32;
  --light: #F9F9F9;
  --light-shaded: #E8E8E8;
  --gray: #7B7B7B;
  --white: #FFFFFF;
}
body {
  font-family: 'Poppins', sans-serif;
  margin: 0;
  padding: 0;
  color: var(--dark);
  background-color: var(--light);
  line-height: 1.6;
}
.container {
  max-width: 1200px;
  margin: auto;
  padding: 0 20px;
}
.app-header {
  background: var(--white);
  box-shadow: 0 2px 8px rgba(0,0,0,0.06);
  position: sticky;
  top: 0;
  z-index: 100;
}
.navbar {
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 20px 0;
}
.logo {
  font-weight: 700;
  font-size: 24px;
  color: var(--primary);
  text-decoration: none;
}
.nav-links, .auth-links {
  display: flex;
  gap: 20px;
}
.nav-links a, .auth-links a {
  color: var(--gray);
  font-weight: 500;
  text-decoration: none;
  transition: color 0.3s;
}
.nav-links a:hover {
  color: var(--primary);
}
.cta-button {
  background: var(--primary);
  color: var(--white);
  padding: 10px 20px;
  border-radius: 6px;
  font-weight: 600;
  text-decoration: none;
  transition: all 0.3s ease;
}
.cta-button:hover {
  background: var(--primary);
  transform: translateY(-2px);
}
.secondary-button {
  background: transparent;
  color: var(--primary);
  border: 2px solid var(--primary);
  padding: 10px 20px;
  border-radius: 6px;
  font-weight: 600;
  text-decoration: none;
  transition: all 0.3s ease;
}
.secondary-button:hover {
  background: transparent;
  transform: translateY(-2px);
}
.hero {
  position: relative;
  height: 100vh;
  display: flex;
  align-items: center;
  text-align: center;
  color: white;
}
.hero-overlay {
  position: absolute;
  inset: 0;
  background-color: rgba(0, 0, 0, 0.4);
}
.hero .container {
  position: relative;
  z-index: 2;
}
.hero h1 {
  font-size: 48px;
  font-weight: 700;
  margin-bottom: 20px;
}
.hero p {
  font-size: 20px;
  max-width: 700px;
  margin: 0 auto 40px;
  opacity: 0.9;
}
.hero-buttons {
  display: flex;
  gap: 15px;
  justify-content: center;
}
.features {
  padding: 80px 0;
  background: var(--light-shaded);
}
.section-title-container {
  display: flex;
  justify-content: center;
  margin-bottom: 60px;
}
.section-title {
  text-align: center;
  font-size: 52px;
  font-weight: 700;
  margin-bottom: 20px;
  letter-spacing: 1px;
  text-transform: uppercase;
  font-family: 'Playfair Display', serif;
  position: relative;
  display: inline-block;
  color: #000000;
}
.section-title::after {
  content: '';
  position: absolute;
  bottom: -15px;
  left: 50%;
  transform: translateX(-50%);
  width: 100px;
  height: 4px;
  background: var(--primary);
  border-radius: 2px;
}
.features-grid {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(280px, 1fr));
  gap: 30px;
}
.feature-card {
  background: var(--cream);
  border-radius: 10px;
  padding: 30px;
  box-shadow: 0 8px 20px rgba(0,0,0,0.05);
  text-align: center;
  color: var(--dark);
  transition: transform 0.3s ease;
}
.feature-card:hover {
  transform: translateY(-5px);
}
.feature-icon {
  font-size: 42px;
  margin-bottom: 15px;
  color: var(--primary);
}
.feature-title {
  font-family: 'Montserrat', sans-serif;
  font-weight: 700;
  font-size: 24px;
  margin-bottom: 12px;
  color: #000000;
  text-transform: uppercase;
  letter-spacing: 1px;
}
.cta-section {
  background: var(--primary);
  color: var(--white);
  padding: 80px 0;
  text-align: center;
}
.cta-title {
  font-family: 'Poppins', sans-serif;
  font-size: 38px;
  font-weight: 700;
  margin-bottom: 20px;
  letter-spacing: 0.5px;
  color: var(--white);
  text-transform: none;
}
.cta-section p {
  max-width: 700px;
  margin: 0 auto 40px;
  font-size: 18px;
  opacity: 0.9;
}
.white-button {
  background: var(--white);
  color: var(--primary);
  padding: 12px 28px;
  border-radius: 6px;
  font-weight: 600;
  text-decoration: none;
  transition: all 0.3s ease;
  font-family: 'Montserrat', sans-serif;
  letter-spacing: 0.5px;
  text-transform: uppercase;
  font-size: 14px;
}
.white-button:hover {
  box-shadow: 0 5px 15px rgba(0,0,0,0.1);
}
.app-footer {
  background: var(--dark);
  color: var(--white);
  padding: 60px 0;
}
.footer-grid {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(220px, 1fr));
  gap: 40px;
}
.footer-logo {
  font-size: 28px;
  font-weight: 700;
  margin-bottom: 20px;
  color: var(--white);
  text-decoration: none;
  font-family: 'Montserrat', sans-serif;
  letter-spacing: 1px;
}
.footer-links h3 {
  margin-bottom: 15px;
  font-family: 'Montserrat', sans-serif;
  font-weight: 700;
  letter-spacing: 0.5px;
  color: var(--cream);
}
.footer-links ul {
  list-style: none;
  padding: 0;
}
.footer-links a {
  color: var(--white);
  opacity: 0.8;
  text-decoration: none;
  transition: opacity 0.3s;
  font-family: 'Poppins', sans-serif;
  font-weight: 500;
}
.footer-links a:hover {
  opacity: 1;
  color: var(--accent);
}
.social-links {
  display: flex;
  gap: 15px;
}
.social-links a {
  color: var(--white);
  font-size: 18px;
  opacity: 0.7;
  transition: all 0.3s ease;
}
.social-links a:hover {
  opacity: 1;
  transform: scale(1.2);
}
.copyright {
  text-align: center;
  margin-top: 40px;
  font-size: 14px;
  opacity: 0.7;
  font-family: 'Montserrat', sans-serif;
  letter-spacing: 0.5px;
}
@media (max-width: 768px) {
  .navbar {
    flex-direction: column;
    gap: 15px;
  }
  .hero h1 {
    font-size: 32px;
  }
  .hero-buttons {
    flex-direction: column;
  }
  .cta-section h2 {
    font-size: 28px;
  }
  .section-title {
    font-size: 42px;
  }
}
.fade-enter-active,
.fade-leave-active {
  transition: opacity 0.3s ease;
}
.fade-enter-from,
.fade-leave-to {
  opacity: 0;
}
</style>