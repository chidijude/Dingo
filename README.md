# Dingo

# Bonus Questions
### 4. Improving Resilience Against Abuse/Exploitation
- **User Tracking**: Add a `UserId` field (currently 0 for anonymous) to track which users are liking an article. This can prevent duplicate likes from the same user.
- **Rate Limiting**: Implement IP-based rate limiting 
- **Bot Detection**: Integrate CAPTCHA or other bot detection mechanisms if the service is open to anonymous users.

### 5. Scaling for Millions of Users
For high traffic, we need a design that minimizes database hits and reduces latency. Some options include:
- **Caching**: Use a distributed cache like Redis to store like counts. For example, increment the count in Redis when a user likes an article and periodically syncs with the database.
- **Message Queueing**: For very high traffic, a message queue like Kafka or Azure Service Bus could handle like requests, which are processed asynchronously.
- **Load Balancing**: Use a load balancer to distribute requests across multiple instances of the API.

### 6. Handling Concurrent Requests
To handle millions of concurrent requests, leverage Redis for atomic increments and distributed locking:

- **Atomic Increment**: Redis offers atomic increment operations, which handle concurrent writes efficiently.
- **Horizontal Scaling**: Deploy multiple instances of the API behind a load balancer. hosting this in Kubernetes or Azure web app offers this services which are configurable with different traffic threshold 
