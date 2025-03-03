<?php
/**
 * PersonalNameParsedOut
 *
 * PHP version 7.4
 *
 * @category Class
 * @package  Namsor\Client
 * @author   OpenAPI Generator team
 * @link     https://openapi-generator.tech
 */

/**
 * NamSor API v2
 *
 * NamSor API v2 : enpoints to process personal names (gender, cultural origin or ethnicity) in all alphabets or languages. By default, enpoints use 1 unit per name (ex. Gender), but Ethnicity classification uses 10 to 20 units per name depending on taxonomy. Use GET methods for small tests, but prefer POST methods for higher throughput (batch processing of up to 100 names at a time). Need something you can't find here? We have many more features coming soon. Let us know, we'll do our best to add it!
 *
 * The version of the OpenAPI document: 2.0.29
 * Contact: contact@namsor.com
 * Generated by: https://openapi-generator.tech
 * Generator version: 7.11.0
 */

/**
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */

namespace Namsor\Client\Model;

use \ArrayAccess;
use \Namsor\Client\ObjectSerializer;

/**
 * PersonalNameParsedOut Class Doc Comment
 *
 * @category Class
 * @package  Namsor\Client
 * @author   OpenAPI Generator team
 * @link     https://openapi-generator.tech
 * @implements \ArrayAccess<string, mixed>
 */
class PersonalNameParsedOut implements ModelInterface, ArrayAccess, \JsonSerializable
{
    public const DISCRIMINATOR = null;

    /**
      * The original name of the model.
      *
      * @var string
      */
    protected static $openAPIModelName = 'PersonalNameParsedOut';

    /**
      * Array of property to type mappings. Used for (de)serialization
      *
      * @var string[]
      */
    protected static $openAPITypes = [
        'script' => 'string',
        'id' => 'string',
        'explanation' => 'string',
        'name' => 'string',
        'name_parser_type' => 'string',
        'name_parser_type_alt' => 'string',
        'first_last_name' => '\Namsor\Client\Model\FirstLastNameOut',
        'score' => 'float'
    ];

    /**
      * Array of property to format mappings. Used for (de)serialization
      *
      * @var string[]
      * @phpstan-var array<string, string|null>
      * @psalm-var array<string, string|null>
      */
    protected static $openAPIFormats = [
        'script' => null,
        'id' => null,
        'explanation' => null,
        'name' => null,
        'name_parser_type' => null,
        'name_parser_type_alt' => null,
        'first_last_name' => null,
        'score' => 'double'
    ];

    /**
      * Array of nullable properties. Used for (de)serialization
      *
      * @var boolean[]
      */
    protected static array $openAPINullables = [
        'script' => false,
        'id' => false,
        'explanation' => false,
        'name' => false,
        'name_parser_type' => false,
        'name_parser_type_alt' => false,
        'first_last_name' => false,
        'score' => false
    ];

    /**
      * If a nullable field gets set to null, insert it here
      *
      * @var boolean[]
      */
    protected array $openAPINullablesSetToNull = [];

    /**
     * Array of property to type mappings. Used for (de)serialization
     *
     * @return array
     */
    public static function openAPITypes()
    {
        return self::$openAPITypes;
    }

    /**
     * Array of property to format mappings. Used for (de)serialization
     *
     * @return array
     */
    public static function openAPIFormats()
    {
        return self::$openAPIFormats;
    }

    /**
     * Array of nullable properties
     *
     * @return array
     */
    protected static function openAPINullables(): array
    {
        return self::$openAPINullables;
    }

    /**
     * Array of nullable field names deliberately set to null
     *
     * @return boolean[]
     */
    private function getOpenAPINullablesSetToNull(): array
    {
        return $this->openAPINullablesSetToNull;
    }

    /**
     * Setter - Array of nullable field names deliberately set to null
     *
     * @param boolean[] $openAPINullablesSetToNull
     */
    private function setOpenAPINullablesSetToNull(array $openAPINullablesSetToNull): void
    {
        $this->openAPINullablesSetToNull = $openAPINullablesSetToNull;
    }

    /**
     * Checks if a property is nullable
     *
     * @param string $property
     * @return bool
     */
    public static function isNullable(string $property): bool
    {
        return self::openAPINullables()[$property] ?? false;
    }

    /**
     * Checks if a nullable property is set to null.
     *
     * @param string $property
     * @return bool
     */
    public function isNullableSetToNull(string $property): bool
    {
        return in_array($property, $this->getOpenAPINullablesSetToNull(), true);
    }

    /**
     * Array of attributes where the key is the local name,
     * and the value is the original name
     *
     * @var string[]
     */
    protected static $attributeMap = [
        'script' => 'script',
        'id' => 'id',
        'explanation' => 'explanation',
        'name' => 'name',
        'name_parser_type' => 'nameParserType',
        'name_parser_type_alt' => 'nameParserTypeAlt',
        'first_last_name' => 'firstLastName',
        'score' => 'score'
    ];

    /**
     * Array of attributes to setter functions (for deserialization of responses)
     *
     * @var string[]
     */
    protected static $setters = [
        'script' => 'setScript',
        'id' => 'setId',
        'explanation' => 'setExplanation',
        'name' => 'setName',
        'name_parser_type' => 'setNameParserType',
        'name_parser_type_alt' => 'setNameParserTypeAlt',
        'first_last_name' => 'setFirstLastName',
        'score' => 'setScore'
    ];

    /**
     * Array of attributes to getter functions (for serialization of requests)
     *
     * @var string[]
     */
    protected static $getters = [
        'script' => 'getScript',
        'id' => 'getId',
        'explanation' => 'getExplanation',
        'name' => 'getName',
        'name_parser_type' => 'getNameParserType',
        'name_parser_type_alt' => 'getNameParserTypeAlt',
        'first_last_name' => 'getFirstLastName',
        'score' => 'getScore'
    ];

    /**
     * Array of attributes where the key is the local name,
     * and the value is the original name
     *
     * @return array
     */
    public static function attributeMap()
    {
        return self::$attributeMap;
    }

    /**
     * Array of attributes to setter functions (for deserialization of responses)
     *
     * @return array
     */
    public static function setters()
    {
        return self::$setters;
    }

    /**
     * Array of attributes to getter functions (for serialization of requests)
     *
     * @return array
     */
    public static function getters()
    {
        return self::$getters;
    }

    /**
     * The original name of the model.
     *
     * @return string
     */
    public function getModelName()
    {
        return self::$openAPIModelName;
    }

    public const NAME_PARSER_TYPE_FN1_LN1 = 'FN1LN1';
    public const NAME_PARSER_TYPE_LN1_FN1 = 'LN1FN1';
    public const NAME_PARSER_TYPE_FN1_LN2 = 'FN1LN2';
    public const NAME_PARSER_TYPE_LN2_FN1 = 'LN2FN1';
    public const NAME_PARSER_TYPE_FN1_LNX = 'FN1LNx';
    public const NAME_PARSER_TYPE_LNX_FN1 = 'LNxFN1';
    public const NAME_PARSER_TYPE_FN2_LN1 = 'FN2LN1';
    public const NAME_PARSER_TYPE_LN1_FN2 = 'LN1FN2';
    public const NAME_PARSER_TYPE_FN2_LN2 = 'FN2LN2';
    public const NAME_PARSER_TYPE_LN2_FN2 = 'LN2FN2';
    public const NAME_PARSER_TYPE_FN2_LNX = 'FN2LNx';
    public const NAME_PARSER_TYPE_LNX_FN2 = 'LNxFN2';
    public const NAME_PARSER_TYPE_FNX_LN1 = 'FNxLN1';
    public const NAME_PARSER_TYPE_LN1_FNX = 'LN1FNx';
    public const NAME_PARSER_TYPE_FNX_LN2 = 'FNxLN2';
    public const NAME_PARSER_TYPE_LN2_FNX = 'LN2FNx';
    public const NAME_PARSER_TYPE_FNX_LNX = 'FNxLNx';
    public const NAME_PARSER_TYPE_LNX_FNX = 'LNxFNx';
    public const NAME_PARSER_TYPE_ALT_FN1_LN1 = 'FN1LN1';
    public const NAME_PARSER_TYPE_ALT_LN1_FN1 = 'LN1FN1';
    public const NAME_PARSER_TYPE_ALT_FN1_LN2 = 'FN1LN2';
    public const NAME_PARSER_TYPE_ALT_LN2_FN1 = 'LN2FN1';
    public const NAME_PARSER_TYPE_ALT_FN1_LNX = 'FN1LNx';
    public const NAME_PARSER_TYPE_ALT_LNX_FN1 = 'LNxFN1';
    public const NAME_PARSER_TYPE_ALT_FN2_LN1 = 'FN2LN1';
    public const NAME_PARSER_TYPE_ALT_LN1_FN2 = 'LN1FN2';
    public const NAME_PARSER_TYPE_ALT_FN2_LN2 = 'FN2LN2';
    public const NAME_PARSER_TYPE_ALT_LN2_FN2 = 'LN2FN2';
    public const NAME_PARSER_TYPE_ALT_FN2_LNX = 'FN2LNx';
    public const NAME_PARSER_TYPE_ALT_LNX_FN2 = 'LNxFN2';
    public const NAME_PARSER_TYPE_ALT_FNX_LN1 = 'FNxLN1';
    public const NAME_PARSER_TYPE_ALT_LN1_FNX = 'LN1FNx';
    public const NAME_PARSER_TYPE_ALT_FNX_LN2 = 'FNxLN2';
    public const NAME_PARSER_TYPE_ALT_LN2_FNX = 'LN2FNx';
    public const NAME_PARSER_TYPE_ALT_FNX_LNX = 'FNxLNx';
    public const NAME_PARSER_TYPE_ALT_LNX_FNX = 'LNxFNx';

    /**
     * Gets allowable values of the enum
     *
     * @return string[]
     */
    public function getNameParserTypeAllowableValues()
    {
        return [
            self::NAME_PARSER_TYPE_FN1_LN1,
            self::NAME_PARSER_TYPE_LN1_FN1,
            self::NAME_PARSER_TYPE_FN1_LN2,
            self::NAME_PARSER_TYPE_LN2_FN1,
            self::NAME_PARSER_TYPE_FN1_LNX,
            self::NAME_PARSER_TYPE_LNX_FN1,
            self::NAME_PARSER_TYPE_FN2_LN1,
            self::NAME_PARSER_TYPE_LN1_FN2,
            self::NAME_PARSER_TYPE_FN2_LN2,
            self::NAME_PARSER_TYPE_LN2_FN2,
            self::NAME_PARSER_TYPE_FN2_LNX,
            self::NAME_PARSER_TYPE_LNX_FN2,
            self::NAME_PARSER_TYPE_FNX_LN1,
            self::NAME_PARSER_TYPE_LN1_FNX,
            self::NAME_PARSER_TYPE_FNX_LN2,
            self::NAME_PARSER_TYPE_LN2_FNX,
            self::NAME_PARSER_TYPE_FNX_LNX,
            self::NAME_PARSER_TYPE_LNX_FNX,
        ];
    }

    /**
     * Gets allowable values of the enum
     *
     * @return string[]
     */
    public function getNameParserTypeAltAllowableValues()
    {
        return [
            self::NAME_PARSER_TYPE_ALT_FN1_LN1,
            self::NAME_PARSER_TYPE_ALT_LN1_FN1,
            self::NAME_PARSER_TYPE_ALT_FN1_LN2,
            self::NAME_PARSER_TYPE_ALT_LN2_FN1,
            self::NAME_PARSER_TYPE_ALT_FN1_LNX,
            self::NAME_PARSER_TYPE_ALT_LNX_FN1,
            self::NAME_PARSER_TYPE_ALT_FN2_LN1,
            self::NAME_PARSER_TYPE_ALT_LN1_FN2,
            self::NAME_PARSER_TYPE_ALT_FN2_LN2,
            self::NAME_PARSER_TYPE_ALT_LN2_FN2,
            self::NAME_PARSER_TYPE_ALT_FN2_LNX,
            self::NAME_PARSER_TYPE_ALT_LNX_FN2,
            self::NAME_PARSER_TYPE_ALT_FNX_LN1,
            self::NAME_PARSER_TYPE_ALT_LN1_FNX,
            self::NAME_PARSER_TYPE_ALT_FNX_LN2,
            self::NAME_PARSER_TYPE_ALT_LN2_FNX,
            self::NAME_PARSER_TYPE_ALT_FNX_LNX,
            self::NAME_PARSER_TYPE_ALT_LNX_FNX,
        ];
    }

    /**
     * Associative array for storing property values
     *
     * @var mixed[]
     */
    protected $container = [];

    /**
     * Constructor
     *
     * @param mixed[]|null $data Associated array of property values
     *                      initializing the model
     */
    public function __construct(?array $data = null)
    {
        $this->setIfExists('script', $data ?? [], null);
        $this->setIfExists('id', $data ?? [], null);
        $this->setIfExists('explanation', $data ?? [], null);
        $this->setIfExists('name', $data ?? [], null);
        $this->setIfExists('name_parser_type', $data ?? [], null);
        $this->setIfExists('name_parser_type_alt', $data ?? [], null);
        $this->setIfExists('first_last_name', $data ?? [], null);
        $this->setIfExists('score', $data ?? [], null);
    }

    /**
    * Sets $this->container[$variableName] to the given data or to the given default Value; if $variableName
    * is nullable and its value is set to null in the $fields array, then mark it as "set to null" in the
    * $this->openAPINullablesSetToNull array
    *
    * @param string $variableName
    * @param array  $fields
    * @param mixed  $defaultValue
    */
    private function setIfExists(string $variableName, array $fields, $defaultValue): void
    {
        if (self::isNullable($variableName) && array_key_exists($variableName, $fields) && is_null($fields[$variableName])) {
            $this->openAPINullablesSetToNull[] = $variableName;
        }

        $this->container[$variableName] = $fields[$variableName] ?? $defaultValue;
    }

    /**
     * Show all the invalid properties with reasons.
     *
     * @return array invalid properties with reasons
     */
    public function listInvalidProperties()
    {
        $invalidProperties = [];

        $allowedValues = $this->getNameParserTypeAllowableValues();
        if (!is_null($this->container['name_parser_type']) && !in_array($this->container['name_parser_type'], $allowedValues, true)) {
            $invalidProperties[] = sprintf(
                "invalid value '%s' for 'name_parser_type', must be one of '%s'",
                $this->container['name_parser_type'],
                implode("', '", $allowedValues)
            );
        }

        $allowedValues = $this->getNameParserTypeAltAllowableValues();
        if (!is_null($this->container['name_parser_type_alt']) && !in_array($this->container['name_parser_type_alt'], $allowedValues, true)) {
            $invalidProperties[] = sprintf(
                "invalid value '%s' for 'name_parser_type_alt', must be one of '%s'",
                $this->container['name_parser_type_alt'],
                implode("', '", $allowedValues)
            );
        }

        if (!is_null($this->container['score']) && ($this->container['score'] > 100)) {
            $invalidProperties[] = "invalid value for 'score', must be smaller than or equal to 100.";
        }

        if (!is_null($this->container['score']) && ($this->container['score'] < 0)) {
            $invalidProperties[] = "invalid value for 'score', must be bigger than or equal to 0.";
        }

        return $invalidProperties;
    }

    /**
     * Validate all the properties in the model
     * return true if all passed
     *
     * @return bool True if all properties are valid
     */
    public function valid()
    {
        return count($this->listInvalidProperties()) === 0;
    }


    /**
     * Gets script
     *
     * @return string|null
     */
    public function getScript()
    {
        return $this->container['script'];
    }

    /**
     * Sets script
     *
     * @param string|null $script script
     *
     * @return self
     */
    public function setScript($script)
    {
        if (is_null($script)) {
            throw new \InvalidArgumentException('non-nullable script cannot be null');
        }
        $this->container['script'] = $script;

        return $this;
    }

    /**
     * Gets id
     *
     * @return string|null
     */
    public function getId()
    {
        return $this->container['id'];
    }

    /**
     * Sets id
     *
     * @param string|null $id id
     *
     * @return self
     */
    public function setId($id)
    {
        if (is_null($id)) {
            throw new \InvalidArgumentException('non-nullable id cannot be null');
        }
        $this->container['id'] = $id;

        return $this;
    }

    /**
     * Gets explanation
     *
     * @return string|null
     */
    public function getExplanation()
    {
        return $this->container['explanation'];
    }

    /**
     * Sets explanation
     *
     * @param string|null $explanation explanation
     *
     * @return self
     */
    public function setExplanation($explanation)
    {
        if (is_null($explanation)) {
            throw new \InvalidArgumentException('non-nullable explanation cannot be null');
        }
        $this->container['explanation'] = $explanation;

        return $this;
    }

    /**
     * Gets name
     *
     * @return string|null
     */
    public function getName()
    {
        return $this->container['name'];
    }

    /**
     * Sets name
     *
     * @param string|null $name The input name.
     *
     * @return self
     */
    public function setName($name)
    {
        if (is_null($name)) {
            throw new \InvalidArgumentException('non-nullable name cannot be null');
        }
        $this->container['name'] = $name;

        return $this;
    }

    /**
     * Gets name_parser_type
     *
     * @return string|null
     */
    public function getNameParserType()
    {
        return $this->container['name_parser_type'];
    }

    /**
     * Sets name_parser_type
     *
     * @param string|null $name_parser_type Name parsing is addressed as a classification problem, for example FN1LN1 means a first then last name order.
     *
     * @return self
     */
    public function setNameParserType($name_parser_type)
    {
        if (is_null($name_parser_type)) {
            throw new \InvalidArgumentException('non-nullable name_parser_type cannot be null');
        }
        $allowedValues = $this->getNameParserTypeAllowableValues();
        if (!in_array($name_parser_type, $allowedValues, true)) {
            throw new \InvalidArgumentException(
                sprintf(
                    "Invalid value '%s' for 'name_parser_type', must be one of '%s'",
                    $name_parser_type,
                    implode("', '", $allowedValues)
                )
            );
        }
        $this->container['name_parser_type'] = $name_parser_type;

        return $this;
    }

    /**
     * Gets name_parser_type_alt
     *
     * @return string|null
     */
    public function getNameParserTypeAlt()
    {
        return $this->container['name_parser_type_alt'];
    }

    /**
     * Sets name_parser_type_alt
     *
     * @param string|null $name_parser_type_alt Second best alternative parsing. Name parsing is addressed as a classification problem, for example FN1LN1 means a first then last name order.
     *
     * @return self
     */
    public function setNameParserTypeAlt($name_parser_type_alt)
    {
        if (is_null($name_parser_type_alt)) {
            throw new \InvalidArgumentException('non-nullable name_parser_type_alt cannot be null');
        }
        $allowedValues = $this->getNameParserTypeAltAllowableValues();
        if (!in_array($name_parser_type_alt, $allowedValues, true)) {
            throw new \InvalidArgumentException(
                sprintf(
                    "Invalid value '%s' for 'name_parser_type_alt', must be one of '%s'",
                    $name_parser_type_alt,
                    implode("', '", $allowedValues)
                )
            );
        }
        $this->container['name_parser_type_alt'] = $name_parser_type_alt;

        return $this;
    }

    /**
     * Gets first_last_name
     *
     * @return \Namsor\Client\Model\FirstLastNameOut|null
     */
    public function getFirstLastName()
    {
        return $this->container['first_last_name'];
    }

    /**
     * Sets first_last_name
     *
     * @param \Namsor\Client\Model\FirstLastNameOut|null $first_last_name first_last_name
     *
     * @return self
     */
    public function setFirstLastName($first_last_name)
    {
        if (is_null($first_last_name)) {
            throw new \InvalidArgumentException('non-nullable first_last_name cannot be null');
        }
        $this->container['first_last_name'] = $first_last_name;

        return $this;
    }

    /**
     * Gets score
     *
     * @return float|null
     */
    public function getScore()
    {
        return $this->container['score'];
    }

    /**
     * Sets score
     *
     * @param float|null $score Higher score is better, but score is not normalized. Use calibratedProbability if available.
     *
     * @return self
     */
    public function setScore($score)
    {
        if (is_null($score)) {
            throw new \InvalidArgumentException('non-nullable score cannot be null');
        }

        if (($score > 100)) {
            throw new \InvalidArgumentException('invalid value for $score when calling PersonalNameParsedOut., must be smaller than or equal to 100.');
        }
        if (($score < 0)) {
            throw new \InvalidArgumentException('invalid value for $score when calling PersonalNameParsedOut., must be bigger than or equal to 0.');
        }

        $this->container['score'] = $score;

        return $this;
    }
    /**
     * Returns true if offset exists. False otherwise.
     *
     * @param integer $offset Offset
     *
     * @return boolean
     */
    public function offsetExists($offset): bool
    {
        return isset($this->container[$offset]);
    }

    /**
     * Gets offset.
     *
     * @param integer $offset Offset
     *
     * @return mixed|null
     */
    #[\ReturnTypeWillChange]
    public function offsetGet($offset)
    {
        return $this->container[$offset] ?? null;
    }

    /**
     * Sets value based on offset.
     *
     * @param int|null $offset Offset
     * @param mixed    $value  Value to be set
     *
     * @return void
     */
    public function offsetSet($offset, $value): void
    {
        if (is_null($offset)) {
            $this->container[] = $value;
        } else {
            $this->container[$offset] = $value;
        }
    }

    /**
     * Unsets offset.
     *
     * @param integer $offset Offset
     *
     * @return void
     */
    public function offsetUnset($offset): void
    {
        unset($this->container[$offset]);
    }

    /**
     * Serializes the object to a value that can be serialized natively by json_encode().
     * @link https://www.php.net/manual/en/jsonserializable.jsonserialize.php
     *
     * @return mixed Returns data which can be serialized by json_encode(), which is a value
     * of any type other than a resource.
     */
    #[\ReturnTypeWillChange]
    public function jsonSerialize()
    {
       return ObjectSerializer::sanitizeForSerialization($this);
    }

    /**
     * Gets the string presentation of the object
     *
     * @return string
     */
    public function __toString()
    {
        return json_encode(
            ObjectSerializer::sanitizeForSerialization($this),
            JSON_PRETTY_PRINT
        );
    }

    /**
     * Gets a header-safe presentation of the object
     *
     * @return string
     */
    public function toHeaderValue()
    {
        return json_encode(ObjectSerializer::sanitizeForSerialization($this));
    }
}


