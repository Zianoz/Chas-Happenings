// AI Chat Bot JavaScript
(function() {
    'use strict';

    // DOM Elements
    const chatMessages = document.getElementById('chatMessages');
    const chatForm = document.getElementById('chatForm');
    const userInput = document.getElementById('userInput');
    const sendBtn = document.getElementById('sendBtn');

    // Utility Functions
    function scrollToBottom() {
        chatMessages.scrollTop = chatMessages.scrollHeight;
    }

    function formatTime() {
        const now = new Date();
        return now.toLocaleTimeString('en-US', { hour: '2-digit', minute: '2-digit' });
    }

    function escapeHtml(text) {
        const div = document.createElement('div');
        div.textContent = text;
        return div.innerHTML;
    }

    function setButtonsDisabled(disabled) {
        userInput.disabled = disabled;
        sendBtn.disabled = disabled;
    }

    // Add User Message
    function addUserMessage(text) {
        const messageEl = document.createElement('div');
        messageEl.className = 'chat-message user';
        messageEl.innerHTML = `
            <div class="message-content">
                <div class="message-bubble">
                    <p class="mb-0">${escapeHtml(text)}</p>
                </div>
                <small class="message-time">${formatTime()}</small>
            </div>
            <div class="message-avatar">
                <i class="fas fa-user"></i>
            </div>
        `;
        chatMessages.appendChild(messageEl);
        scrollToBottom();
    }

    // Add Bot Message
    function addBotMessage(text) {
        const messageEl = document.createElement('div');
        messageEl.className = 'chat-message bot';
        const formattedText = text.replace(/\n/g, '<br>');
        messageEl.innerHTML = `
            <div class="message-avatar">
                <i class="fas fa-calendar-alt"></i>
            </div>
            <div class="message-content">
                <div class="message-bubble">
                    <p class="mb-0">${formattedText}</p>
                </div>
                <small class="message-time">${formatTime()}</small>
            </div>
        `;
        chatMessages.appendChild(messageEl);
        scrollToBottom();
    }

    // Show Typing Indicator
    function showTypingIndicator() {
        const typingEl = document.createElement('div');
        typingEl.className = 'chat-message bot';
        typingEl.id = 'typingIndicator';
        typingEl.innerHTML = `
            <div class="message-avatar">
                <i class="fas fa-calendar-alt"></i>
            </div>
            <div class="message-content">
                <div class="message-bubble">
                    <div class="typing-indicator">
                        <span></span>
                        <span></span>
                        <span></span>
                    </div>
                </div>
            </div>
        `;
        chatMessages.appendChild(typingEl);
        scrollToBottom();
    }

    // Hide Typing Indicator
    function hideTypingIndicator() {
        const typingEl = document.getElementById('typingIndicator');
        if (typingEl) {
            typingEl.remove();
        }
    }

    // Handle Form Submit
    chatForm.addEventListener('submit', async function(e) {
        e.preventDefault();

        const message = userInput.value.trim();
        if (!message) return;

        // Disable controls
        setButtonsDisabled(true);

        // Add user message
        addUserMessage(message);
        userInput.value = '';

        // Show typing
        showTypingIndicator();

        try {
            const response = await fetch('/api/OpenAI/generate', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ prompt: message })
            });

            if (!response.ok) {
                throw new Error('Failed to get AI response');
            }

            const data = await response.json();
            hideTypingIndicator();
            addBotMessage(data.answer || 'Sorry, I couldn\'t process that request.');

        } catch (error) {
            console.error('Error:', error);
            hideTypingIndicator();
            addBotMessage('Sorry, something went wrong. Please try again later.');
        } finally {
            setButtonsDisabled(false);
            userInput.focus();
        }
    });

    // Focus input on load
    userInput.focus();
})();
