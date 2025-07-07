<template>
  <div class="center-container">
    <div class="max-w-xl mx-auto mt-10 p-8 bg-baby-blue shadow rounded">
      <h1 class="text-2xl font-semibold mb-6">Smart Chatbot Assistant</h1>
      <input
        v-model="userInput"
        @keyup.enter="handleAsk"
        placeholder="Type your question..."
        class="w-full px-4 py-3 border border-baby-blue-light rounded mb-6"
      />
      <div class="flex justify-between gap-4 mb-6">
        <button
          @click="handleAsk"
          class="flex-1 bg-baby-blue-dark text-white px-4 py-3 rounded hover:bg-baby-blue-darker"
        >
          Ask
        </button>
        <button
          @click="clearAnswer"
          class="flex-1 bg-baby-blue-light text-baby-blue-dark px-4 py-3 rounded hover:bg-baby-blue"
        >
          Clear
        </button>
      </div>
      <div
        v-if="lastResponse"
        class="p-6 border border-baby-blue-light bg-baby-blue-lightest rounded text-baby-blue-dark shadow-sm"
      >
        {{ lastResponse }}
      </div>
    </div>
  </div>
</template>

<script>
import { ref } from 'vue';

export default {
  setup() {
    const userInput = ref('');
    const lastResponse = ref('');
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
      "how to contact support": "You'll receive email updates automatically – for more help, use our contact form.",
      "how do admins login": "Admins log in the same way, but their account has extra permissions.",
      "what tech is used in this portal": "We use Vue.js for the frontend and ASP.NET Core for the backend.",
      "how are emails sent": "Emails are powered by MailKit, using Mailtrap in development.",
      "can i cancel a request": "For now, cancellations aren't in the UI – contact admin if needed.",
      "how do i edit a shipping request": "Editing is restricted; if needed, contact support or admin.",
      "what is the chatbot for": "I'm here to answer your questions about using the Smart Portal.",
      "can i use this on mobile": "Yes! The site is mobile-responsive for use on any device.",
      "how to deploy frontend": "Use Vercel – connect your repo and it auto-deploys with every commit.",
      "how to deploy backend": "Deploy on Render – configure secrets, build command, and hit deploy.",
      "can i dockerize this": "Definitely – the backend supports Docker and even docker-compose.",
      "where is data stored": "Data is stored securely in a database like SQL Server or MongoDB.",
      "how to add admin users": "Admins are added by updating the user's role in the database.",
      "how are analytics generated": "The backend provides summary APIs which the charts use to display insights.",
      "what are future improvements": "Live chat, payment systems, more automation – lots to come!"
    };

    function handleAsk() {
      let question = userInput.value.trim().toLowerCase();
      question = question.replace(/^["']|["']$/g, '').replace(/[?.!]*$/, '');
      const matchedKey = Object.keys(answerMap).find(key =>
        key.toLowerCase().replace(/[?.!]*$/, '') === question
      );
      lastResponse.value = matchedKey
        ? answerMap[matchedKey]
        : "Hmm... I'm not sure about that yet. Try asking another way!";
      userInput.value = '';
    }

    function clearAnswer() {
      userInput.value = '';
      lastResponse.value = '';
    }

    return {
      userInput,
      lastResponse,
      handleAsk,
      clearAnswer
    };
  }
};
</script>

<style scoped>
.center-container {
  display: flex;
  justify-content: center;
  align-items: flex-start;
  height: 100vh;
  width: 100vw;
  margin-top: 50px;
}
.max-w-xl {
  max-width: 38rem;
}
.mx-auto {
  margin-left: auto;
  margin-right: auto;
}
.mt-10 {
  margin-top: 2.5rem;
}
.p-8 {
  padding: 2rem;
}
.bg-baby-blue {
  background-color: #E0F7FA;
}
.shadow {
  box-shadow: 0 1px 3px 0 rgba(0, 0, 0, 0.1), 0 1px 2px 0 rgba(0, 0, 0, 0.06);
}
.rounded {
  border-radius: 0.375rem;
}
.text-2xl {
  font-size: 1.5rem;
  line-height: 2rem;
}
.font-semibold {
  font-weight: 600;
}
.mb-6 {
  margin-bottom: 1.5rem;
}
.w-full {
  width: 100%;
}
.px-4 {
  padding-left: 1rem;
  padding-right: 1rem;
}
.py-3 {
  padding-top: 0.75rem;
  padding-bottom: 0.75rem;
}
.border {
  border-width: 1px;
}
.border-baby-blue-light {
  border-color: #B3E5FC;
}
.rounded {
  border-radius: 0.375rem;
}
.mb-6 {
  margin-bottom: 1.5rem;
}
.flex {
  display: flex;
}
.justify-between {
  justify-content: space-between;
}
.gap-4 {
  gap: 1rem;
}
.bg-baby-blue-dark {
  background-color: #81D4FA;
}
.text-white {
  color: #ffffff;
}
.hover\:bg-baby-blue-darker:hover {
  background-color: #4FC3F7;
}
.flex-1 {
  flex: 1 1 0%;
}
.bg-baby-blue-light {
  background-color: #B3E5FC;
}
.text-baby-blue-dark {
  color: #0288D1;
}
.hover\:bg-baby-blue:hover {
  background-color: #81D4FA;
}
.p-6 {
  padding: 1.5rem;
}
.border-baby-blue-light {
  border-color: #B3E5FC;
}
.bg-baby-blue-lightest {
  background-color: #F0F8FF;
}
.text-baby-blue-dark {
  color: #0288D1;
}
.shadow-sm {
  box-shadow: 0 1px 2px 0 rgba(0, 0, 0, 0.05);
}
</style>