FROM python:3.6.5-slim
ENV FLASK_APP=chatty.py
WORKDIR /app
RUN pip install flask
COPY . /app
CMD flask run --host=0.0.0.0