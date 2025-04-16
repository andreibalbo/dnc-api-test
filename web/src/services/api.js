import axios from 'axios';

const apiClient = axios.create({
  baseURL: 'http://localhost:5002/api',
  headers: {
    'Content-Type': 'application/json'
  }
});

export const postService = {
  getAll() {
    return apiClient.get('/post');
  },
  getById(id) {
    return apiClient.get(`/post/${id}`);
  },
  create(post) {
    return apiClient.post('/post', post);
  },
  update(id, post) {
    return apiClient.put(`/post/${id}`, post);
  },
  delete(id) {
    return apiClient.delete(`/post/${id}`);
  }
};
