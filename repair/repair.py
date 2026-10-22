import time
from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
from selenium.webdriver.chrome.options import Options

def test_login_form():
    # ИСПРАВЛЕНИЕ 1: Настройка опций Chrome для обхода ошибки Sandbox
    options = Options()
    options.add_argument("--no-sandbox")
    options.add_argument("--disable-dev-shm-usage")
    
    
    driver = webdriver.Chrome(options=options)
    driver.maximize_window()
    
    try:
        driver.get("https://b2c.passport.rt.ru")
        
        # ИСПРАВЛЕНИЕ 2: Добавлено ожидание загрузки страницы
        WebDriverWait(driver, 10).until(
            EC.presence_of_element_located((By.ID, "t-btn-tab-login"))
        )

        # ИСПРАВЛЕНИЕ 3: Локатор вкладки 
        login_tab = driver.find_element(By.ID, "t-btn-tab-login")
        login_tab.click()

        # ИСПРАВЛЕНИЕ 4: Пауза для появления полей ввода
        time.sleep(1) 

        
        username = driver.find_element(By.ID, "username")
        username.send_keys("test_user")

        password = driver.find_element(By.ID, "password")
        password.send_keys("test_password")

        login_btn = driver.find_element(By.ID, "kc-login")
        login_btn.click()

        # ИСПРАВЛЕНИЕ 5: Исправлен класс ошибки + добавлено ожидание
        # Если сайт снова изменился и тест падает с TimeoutException, 
        # найди актуальный класс через F12 (DevTools) и замени его здесь.
        error_msg = WebDriverWait(driver, 10).until(
            EC.visibility_of_element_located((By.CLASS_NAME, "card-error__message"))
        )
        
        # ИСПРАВЛЕНИЕ 6: Проверяем, что текст ошибки не пустой / ru
        
        assert error_msg.text != "", "Сообщение об ошибке пустое"

        print("Test passed successfully!")

    finally:
        
        time.sleep(1)
        driver.quit()

if __name__ == "__main__":
    test_login_form()
