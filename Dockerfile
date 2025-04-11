FROM mcr.microsoft.com/dotnet/sdk:8.0

WORKDIR /app

# Install basic tools if needed
RUN apt-get update && apt-get install -y \
  git \
  && rm -rf /var/lib/apt/lists/*

EXPOSE 5000
EXPOSE 5001

# Keep container running
CMD ["sleep", "infinity"] 
