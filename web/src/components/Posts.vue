<template>
  <div class="posts">
    <h2>Posts</h2>

    <!-- Create Post Form -->
    <div class="post-form">
      <h3>{{ editMode ? 'Edit Post' : 'Create New Post' }}</h3>
      <form @submit.prevent="submitPost">
        <input v-model="form.title" type="text" placeholder="Title" required />
        <textarea
          v-model="form.content"
          placeholder="Content"
          required
        ></textarea>
        <button type="submit">{{ editMode ? 'Update' : 'Create' }}</button>
        <button v-if="editMode" type="button" @click="cancelEdit">
          Cancel
        </button>
      </form>
    </div>

    <!-- Posts List -->
    <div class="posts-list">
      <div v-for="post in posts" :key="post.id" class="post-item">
        <h3>{{ post.title }}</h3>
        <p>{{ post.content }}</p>
        <div class="actions">
          <button @click="editPost(post)">Edit</button>
          <button @click="deletePost(post.id)">Delete</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { postService } from '@/services/api';

export default {
  name: 'Posts',
  data() {
    return {
      posts: [],
      form: {
        title: '',
        content: ''
      },
      editMode: false,
      editId: null
    };
  },
  async created() {
    await this.loadPosts();
  },
  methods: {
    async loadPosts() {
      try {
        const response = await postService.getAll();
        this.posts = response.data;
      } catch (error) {
        console.error('Error loading posts:', error);
      }
    },
    async submitPost() {
      try {
        if (this.editMode) {
          await postService.update(this.editId, this.form);
        } else {
          await postService.create(this.form);
        }
        this.resetForm();
        await this.loadPosts();
      } catch (error) {
        console.error('Error submitting post:', error);
      }
    },
    editPost(post) {
      this.editMode = true;
      this.editId = post.id;
      this.form = {
        title: post.title,
        content: post.content
      };
    },
    async deletePost(id) {
      if (confirm('Are you sure you want to delete this post?')) {
        try {
          await postService.delete(id);
          await this.loadPosts();
        } catch (error) {
          console.error('Error deleting post:', error);
        }
      }
    },
    cancelEdit() {
      this.resetForm();
    },
    resetForm() {
      this.form = {
        title: '',
        content: ''
      };
      this.editMode = false;
      this.editId = null;
    }
  }
};
</script>

<style scoped>
.posts {
  max-width: 800px;
  margin: 0 auto;
  padding: 20px;
}

.post-form {
  margin-bottom: 30px;
  padding: 20px;
  background-color: #f5f5f5;
  border-radius: 8px;
}

.post-form form {
  display: flex;
  flex-direction: column;
  gap: 10px;
}

input,
textarea {
  padding: 8px;
  border: 1px solid #ddd;
  border-radius: 4px;
}

textarea {
  min-height: 100px;
}

button {
  padding: 8px 16px;
  background-color: #4caf50;
  color: white;
  border: none;
  border-radius: 4px;
  cursor: pointer;
}

button:hover {
  background-color: #45a049;
}

.post-item {
  margin-bottom: 20px;
  padding: 15px;
  border: 1px solid #ddd;
  border-radius: 8px;
}

.actions {
  margin-top: 10px;
}

.actions button {
  margin-right: 10px;
}

.actions button:last-child {
  background-color: #f44336;
}

.actions button:last-child:hover {
  background-color: #da190b;
}
</style>
