// Example API service file showing how to use the axios instance
// This file demonstrates best practices for organizing API calls

import api from './axios';

// ============================================
// USER API CALLS
// ============================================

export const userAPI = {
  // Login user
  login: async (email, password) => {
    const response = await api.post('/User/LoginUser', { email, password });
    return response.data; // Returns the token
  },

  authenticate: async () => {
    const response = await api.get('/User/Authenticate', {
      withCredentials: true,
    });
    return response.data;
  },

  // Create new user
  createUser: async (userData) => {
    const response = await api.post('/User', userData);
    return response.data;
  },

  // Get user by ID
  getUserById: async (userId) => {
    const response = await api.get(`/User/GetUserById/${userId}`);
    return response.data;
  },

  // Update user
  updateUser: async (userId, userData) => {
    const response = await api.put(`/User/UpdateUserById/${userId}`, userData);
    return response.data;
  },

  // Delete user
  deleteUser: async (userId) => {
    const response = await api.delete(`/User/Delete/${userId}`);
    return response.data;
  },

  // Get all users
  getAllUsers: async () => {
    const response = await api.get('/User/GetAll');
    return response.data;
  },
};

// ============================================
// EVENT API CALLS
// ============================================

export const eventAPI = {
  // Get all events
  getAllEvents: async () => {
    const response = await api.get('/Event/GetAll');
    return response.data;
  },

  // Get event by ID
  getEventById: async (eventId) => {
    const response = await api.get(`/Event/${eventId}`);
    return response.data;
  },

  // Create event
  createEvent: async (eventData) => {
    const response = await api.post('/Event', eventData);
    return response.data;
  },

  // Update event
  updateEvent: async (eventId, eventData) => {
    const response = await api.put(`/Event/${eventId}`, eventData);
    return response.data;
  },

  // Delete event
  deleteEvent: async (eventId) => {
    const response = await api.delete(`/Event/${eventId}`);
    return response.data;
  },
};

// ============================================
// COMMENT API CALLS
// ============================================

export const commentAPI = {
  // Get comments by event ID
  getCommentsByEventId: async (eventId) => {
    const response = await api.get(`/Comment/event/${eventId}`);
    return response.data;
  },

  // Create comment
  createComment: async (commentData) => {
    const response = await api.post('/Comment', commentData);
    return response.data;
  },

  // Update comment
  updateComment: async (commentId, commentData) => {
    const response = await api.put(`/Comment/${commentId}`, commentData);
    return response.data;
  },

  // Delete comment
  deleteComment: async (commentId) => {
    const response = await api.delete(`/Comment/${commentId}`);
    return response.data;
  },
};

// ============================================
// TAG API CALLS
// ============================================

export const tagAPI = {
  // Get all tags
  getAllTags: async () => {
    const response = await api.get('/Tag/GetAll');
    return response.data;
  },

  // Create tag
  createTag: async (tagData) => {
    const response = await api.post('/Tag', tagData);
    return response.data;
  },

  // Update tag
  updateTag: async (tagId, tagData) => {
    const response = await api.put(`/Tag/${tagId}`, tagData);
    return response.data;
  },

  // Delete tag
  deleteTag: async (tagId) => {
    const response = await api.delete(`/Tag/${tagId}`);
    return response.data;
  },
};
