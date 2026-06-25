SET NAMES utf8mb4;

CREATE TABLE IF NOT EXISTS mst_enemy (
    id INT UNSIGNED PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(50) NOT NULL,
    lv TINYINT UNSIGNED NOT NULL,
    max_hp INT UNSIGNED NOT NULL,
    atk INT UNSIGNED NOT NULL,
    def INT UNSIGNED NOT NULL,
    agi INT UNSIGNED NOT NULL,
    evasion_rate TINYINT UNSIGNED NOT NULL DEFAULT 0,
    critical_rate TINYINT UNSIGNED NOT NULL DEFAULT 0,
    exp_reward INT UNSIGNED NOT NULL DEFAULT 0,
    gold_reward INT UNSIGNED NOT NULL DEFAULT 0,
    enemy_type TINYINT UNSIGNED NOT NULL DEFAULT 1,
    escape_type TINYINT UNSIGNED NOT NULL DEFAULT 1,
    created_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    CONSTRAINT uq_mst_enemy_name UNIQUE (name),
    INDEX idx_mst_enemy_type (enemy_type)
);

INSERT INTO mst_enemy
    (name, lv, max_hp, atk, def, agi, evasion_rate, critical_rate, exp_reward, gold_reward, enemy_type, escape_type)
VALUES
    ('スライム', 1, 8, 3, 1, 2, 2, 1, 2, 1, 1, 1),
    ('ゴブリン', 2, 16, 5, 2, 3, 3, 2, 5, 3, 1, 1),
    ('ウルフ', 3, 24, 7, 3, 6, 6, 4, 8, 5, 1, 1)
ON DUPLICATE KEY UPDATE
    lv = VALUES(lv),
    max_hp = VALUES(max_hp),
    atk = VALUES(atk),
    def = VALUES(def),
    agi = VALUES(agi),
    evasion_rate = VALUES(evasion_rate),
    critical_rate = VALUES(critical_rate),
    exp_reward = VALUES(exp_reward),
    gold_reward = VALUES(gold_reward),
    enemy_type = VALUES(enemy_type),
    escape_type = VALUES(escape_type);