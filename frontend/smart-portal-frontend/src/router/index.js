import { createRouter, createWebHistory } from 'vue-router'

import LoginPage from '../pages/LoginPage.vue'
import SignupPage from '../pages/SignupPage.vue'
import ProfilePage from '../pages/ProfilePage.vue'
import SourcingRequestPage from '../pages/SourcingRequestPage.vue'
import ShippingCalculatorPage from '../pages/ShippingCalculatorPage.vue'
import TrackingDashboardPage from '../pages/TrackingDashboardPage.vue'
import AdminPanel from '../pages/AdminPanel.vue'
import AdminDashboard from '../pages/AdminDashboard.vue'

const routes = [
  { path: '/login', name: 'Login', component: LoginPage },
  { path: '/signup', name: 'Signup', component: SignupPage },
  { path: '/profile', name: 'Profile', component: ProfilePage },
  { path: '/sourcing', name: 'Sourcing', component: SourcingRequestPage },
  { path: '/shipping', name: 'Shipping', component: ShippingCalculatorPage },
  { path: '/tracking', name: 'Tracking', component: TrackingDashboardPage },
  { path: '/admin', name: 'Admin', component: AdminPanel },
  { path: '/admin-dashboard', name: 'AdminDashboard', component: AdminDashboard }
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

export default router
