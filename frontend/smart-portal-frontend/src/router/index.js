import { createRouter, createWebHistory } from 'vue-router'

import LoginPage from '../pages/LoginPage.vue'
import SignupPage from '../pages/SignupPage.vue'
import ProfilePage from '../pages/ProfilePage.vue'
import SourcingRequestPage from '../pages/SourcingRequestPage.vue'
import ShippingCalculatorPage from '../pages/ShippingCalculatorPage.vue'
import TrackingDashboardPage from '../pages/TrackingDashboardPage.vue'
import AdminPanel from '../pages/AdminPanel.vue'
import AdminAnalytics from '../pages/AdminAnalytics.vue'
import ChatbotPage from '../pages/ChatbotPage.vue' // ✅ Added

const routes = [
  { path: '/login', name: 'Login', component: LoginPage },
  { path: '/signup', name: 'Signup', component: SignupPage },
  { path: '/profile', name: 'Profile', component: ProfilePage },
  { path: '/sourcing', name: 'Sourcing', component: SourcingRequestPage },
  { path: '/shipping', name: 'Shipping', component: ShippingCalculatorPage },
  { path: '/tracking', name: 'Tracking', component: TrackingDashboardPage },
  { path: '/admin', name: 'Admin', component: AdminPanel },
  {
    path: '/admin-analytics',
    name: 'AdminAnalytics',
    component: AdminAnalytics,
    meta: { requiresAuth: true, requiresAdmin: true }
  },
  { path: '/chatbot', name: 'Chatbot', component: ChatbotPage } // ✅ Added chatbot route
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

export default router
