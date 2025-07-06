<template>
  <div class="center-container">
    <div class="max-w-xl mx-auto mt-10 p-6 bg-white shadow rounded">
      <h1 class="text-2xl font-semibold mb-4">Smart Chatbot Assistant☁️</h1>
      <input
        v-model="userInput"
        @keyup.enter="handleAsk"
        placeholder="Type your question..."
        class="w-full px-3 py-2 border border-gray-300 rounded mb-4"
      />
      <div class="flex justify-between gap-2 mb-4">
        <button
          @click="handleAsk"
          class="flex-1 bg-blue-600 text-white px-3 py-2 rounded hover:bg-blue-700"
        >
          Ask
        </button>
        <button
          @click="clearAnswer"
          class="flex-1 bg-gray-300 text-black px-3 py-2 rounded hover:bg-gray-400"
        >
          Clear
        </button>
      </div>
      <div
        v-if="lastResponse"
        class="p-4 border border-gray-200 bg-gray-50 rounded text-gray-800 shadow-sm"
      >
        {{ lastResponse }}
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue'
const userInput = ref('')
const lastResponse = ref('')
const answerMap = {
  "what is sourcing": "Sourcing is how we find and get the best products or services for your needs.",
  "how do i submit a sourcing request": "Just head over to the Sourcing page, fill out the form, and submit.",
  "what is smart shipping": "Smart shipping finds the fastest and cheapest delivery options using real-time data.",
  "how to track my package": "Visit the Tracking page and enter your tracking ID to see live status.",
  "what is the shipping calculator": "It estimates your shipping cost based on weight, location, and speed.",
  "who can access the analytics dashboard": "Only admin users can view detailed charts in the Analytics section.",
  "how do i sign up": "Click the Signup link above and register with your email and password.",
  "can i update my profile": "Yes! Navigate to the Profile page and make your changes.",
  "is login required": "Yes, login is needed to access features like tracking, sourcing, and profile editing.",
  "what is jwt": "JWT stands for JSON Web Token – it helps securely identify logged-in users.",
  "how to contact support": "You’ll receive email updates automatically – for more help, use our contact form.",
  "how do admins login": "Admins log in the same way, but their account has extra permissions.",
  "what tech is used in this portal": "We use Vue.js for the frontend and ASP.NET Core for the backend.",
  "how are emails sent": "Emails are powered by MailKit, using Mailtrap in development.",
  "can i cancel a request": "For now, cancellations aren’t in the UI – contact admin if needed.",
  "how do i edit a shipping request": "Editing is restricted; if needed, contact support or admin.",
  "what is the chatbot for": "I'm here to answer your questions about using the Smart Portal.",
  "can i use this on mobile": "Yes! The site is mobile-responsive for use on any device.",
  "how to deploy frontend": "Use Vercel – connect your repo and it auto-deploys with every commit.",
  "how to deploy backend": "Deploy on Render – configure secrets, build command, and hit deploy.",
  "can i dockerize this": "Definitely – the backend supports Docker and even docker-compose.",
  "where is data stored": "Data is stored securely in a database like SQL Server or MongoDB.",
  "how to add admin users": "Admins are added by updating the user’s role in the database.",
  "how are analytics generated": "The backend provides summary APIs which the charts use to display insights.",
  "what are future improvements": "Live chat, payment systems, more automation – lots to come!"
}
function handleAsk() {
  let question = userInput.value.trim().toLowerCase()
  question = question.replace(/^["']|["']$/g, '').replace(/[?.!]*$/, '')
  const matchedKey = Object.keys(answerMap).find(key =>
    key.toLowerCase().replace(/[?.!]*$/, '') === question
  )
  lastResponse.value = matchedKey
    ? answerMap[matchedKey]
    : "Hmm... I’m not sure about that yet. Try asking another way!"
  userInput.value = ''
}
function clearAnswer() {
  userInput.value = ''
  lastResponse.value = ''
}
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