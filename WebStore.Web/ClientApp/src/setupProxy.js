const { createProxyMiddleware } = require('http-proxy-middleware');
const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:44419` :
  env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'http://localhost:62228';

const onError = (err, req, resp, target) => {
    console.error(`${err.message}`);
}

const context = [
    "api/",
    "/swagger"
]   

module.exports = function (app) {
  const appProxy = createProxyMiddleware(context, {
    target: target,
    onError: onError,
    secure: false,
    headers: {
      Connection: 'Keep-Alive'
    }
  });

  app.use(appProxy);
};
