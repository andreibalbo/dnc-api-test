# Use Node.js as base image
FROM node:20-alpine

# Set working directory
WORKDIR /app

# Install yarn globally
RUN npm install -g yarn

# Install Vue CLI globally (using yarn)
RUN yarn global add @vue/cli

# Copy package files
COPY package*.json ./

# Install dependencies
RUN yarn install

# Copy project files
COPY . .

# Expose port 8080
EXPOSE 8080

# Command to run the development server
CMD ["yarn", "serve"] 