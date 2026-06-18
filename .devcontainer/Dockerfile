# See here for image contents: https://github.com/devcontainers/images/tree/main/src/dotnet

# [Choice] .NET version: 8.0, 9.0, 10.0
# .NET 10+: use -noble (Ubuntu 24.04) e.g. 10.0-noble
# .NET 8/9: use -bookworm-slim (Debian 12) e.g. 9.0-bookworm-slim
ARG VARIANT="10.0-noble"
FROM mcr.microsoft.com/devcontainers/dotnet:${VARIANT}

# Install Node.js LTS (22.x)
RUN curl -fsSL https://deb.nodesource.com/setup_22.x | bash -
RUN apt-get install -y nodejs

# Install Python
RUN apt-get update && apt-get install -y python3 python3-pip

# Install act to run GitHub Actions locally
RUN curl --proto '=https' --tlsv1.2 -sSf https://raw.githubusercontent.com/nektos/act/master/install.sh | sudo bash

# [Optional] Uncomment this section to install additional OS packages.
# RUN apt-get update && export DEBIAN_FRONTEND=noninteractive \
#     && apt-get -y install --no-install-recommends <your-package-list-here>

# [Optional] Uncomment this line to install global node packages.
# RUN su vscode -c "source /usr/local/share/nvm/nvm.sh && npm install -g <your-package-here>" 2>&1