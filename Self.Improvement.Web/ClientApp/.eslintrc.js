module.exports = {
    env: {
        "browser": true,
        "es6": true,
        "node": true
    },
    parser: "@typescript-eslint/parser",
    parserOptions: {
        sourceType: "module",
        project: "./tsconfig.json",
    },
    plugins: [
        "eslint-plugin-import",
        "@angular-eslint/eslint-plugin",
        "@typescript-eslint",
        "@typescript-eslint/tslint",
        "indent-class-properties",
        "unused-imports",
    ],
    rules: {
        "indent": [
            "error",
            4,
            {
                "SwitchCase": 1,
                "VariableDeclarator": "first",
                "MemberExpression": 2,
                "ArrayExpression": 1,
            }
        ],
        "indent-class-properties/indent": ["error", 4],
        "no-multi-spaces": "error",
        "newline-after-var": [
            "error",
            "always"
        ],
        "newline-before-return": "error",
        "no-multiple-empty-lines": [
            "error",
            {
                "max": 1,
                "maxEOF": 0,
                "maxBOF": 0
            }
        ],
        "@angular-eslint/component-class-suffix": "error",
        "@angular-eslint/directive-class-suffix": "error",
        "@angular-eslint/no-host-metadata-property": "error",
        "@angular-eslint/no-input-rename": "error",
        "@angular-eslint/no-inputs-metadata-property": "error",
        "@angular-eslint/no-output-rename": "error",
        "@angular-eslint/no-outputs-metadata-property": "error",
        "@angular-eslint/use-pipe-transform-interface": "error",
        "@typescript-eslint/consistent-type-definitions": "error",
        "@typescript-eslint/dot-notation": "off",
        "@typescript-eslint/explicit-member-accessibility": ["error"],
        "@typescript-eslint/explicit-function-return-type": ["error"],
        "@typescript-eslint/member-delimiter-style": [
            "error",
            {
                "multiline": {
                    "delimiter": "semi",
                    "requireLast": true
                },
                "singleline": {
                    "delimiter": "semi",
                    "requireLast": true
                }
            }
        ],
        "@typescript-eslint/no-empty-interface": "warn",
        "@typescript-eslint/no-inferrable-types": [
            "error",
            {
                "ignoreParameters": true
            }
        ],
        "@typescript-eslint/no-misused-new": "error",
        "@typescript-eslint/no-non-null-assertion": "error",
        "@typescript-eslint/prefer-function-type": "error",
        "@typescript-eslint/quotes": [
            "error",
            "single"
        ],
        "@typescript-eslint/semi": [
            "error",
            "always"
        ],
        "@typescript-eslint/type-annotation-spacing": "error",
        "@typescript-eslint/unified-signatures": "error",
        "@typescript-eslint/tslint/config": [
            "error",
            {
                "rules": {
                    "import-spacing": true,
                    "whitespace": [
                        true,
                        "check-branch",
                        "check-decl",
                        "check-operator",
                        "check-separator",
                        "check-type"
                    ]
                }
            }
        ],
        "constructor-super": "error",
        "eol-last": "error",
        "guard-for-in": "error",
        "id-blacklist": "off",
        "id-match": "off",
        "import/no-deprecated": "warn",
        "no-bitwise": "error",
        "no-caller": "error",
        "unused-imports/no-unused-imports": "error",
        "no-console": [
            "error",
            {
                "allow": [
                    "log",
                    "dirxml",
                    "warn",
                    "error",
                    "dir",
                    "timeLog",
                    "assert",
                    "clear",
                    "count",
                    "countReset",
                    "group",
                    "groupCollapsed",
                    "groupEnd",
                    "table",
                    "Console",
                    "markTimeline",
                    "profile",
                    "profileEnd",
                    "timeline",
                    "timelineEnd",
                    "timeStamp",
                    "context"
                ]
            }
        ],
        "no-debugger": "error",
        "no-empty": "off",
        "no-eval": "error",
        "no-new-wrappers": "error",
        "no-restricted-imports": [
            "error",
            "rxjs/Rx"
        ],
        "no-trailing-spaces": "error",
        "no-undef-init": "error",
        "no-underscore-dangle": "off",
        "no-unused-labels": "error",
        "no-extra-boolean-cast": "error",
        "no-unreachable": "error",
        "no-redeclare": "error",
        "no-return-await": "error",
        "no-useless-call": "error",
        "no-useless-catch": "error",
        "no-useless-concat": "error",
        "no-useless-return": "error",
        "no-useless-rename": "error",
        "array-bracket-spacing": ["error", "never"],
        "space-in-parens": ["error", "never"],
        "object-curly-spacing": ["error", "always"],
        "no-duplicate-imports": "error",
        "no-var": "error",
        "prefer-const": "error",
        "spaced-comment": [
            "error",
            "always",
            {
                "markers": [
                    "/"
                ]
            }
        ],
    }
};