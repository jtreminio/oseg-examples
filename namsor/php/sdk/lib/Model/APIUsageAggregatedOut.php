<?php
/**
 * APIUsageAggregatedOut
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
 * APIUsageAggregatedOut Class Doc Comment
 *
 * @category Class
 * @package  Namsor\Client
 * @author   OpenAPI Generator team
 * @link     https://openapi-generator.tech
 * @implements \ArrayAccess<string, mixed>
 */
class APIUsageAggregatedOut implements ModelInterface, ArrayAccess, \JsonSerializable
{
    public const DISCRIMINATOR = null;

    /**
      * The original name of the model.
      *
      * @var string
      */
    protected static $openAPIModelName = 'APIUsageAggregatedOut';

    /**
      * Array of property to type mappings. Used for (de)serialization
      *
      * @var string[]
      */
    protected static $openAPITypes = [
        'time_unit' => 'string',
        'period_start' => 'int',
        'period_end' => 'int',
        'total_usage' => 'int',
        'history_truncated' => 'bool',
        'data' => 'int[][]',
        'col_headers' => 'string[]',
        'row_headers' => 'string[]'
    ];

    /**
      * Array of property to format mappings. Used for (de)serialization
      *
      * @var string[]
      * @phpstan-var array<string, string|null>
      * @psalm-var array<string, string|null>
      */
    protected static $openAPIFormats = [
        'time_unit' => null,
        'period_start' => 'int64',
        'period_end' => 'int64',
        'total_usage' => 'int64',
        'history_truncated' => null,
        'data' => 'int32',
        'col_headers' => null,
        'row_headers' => null
    ];

    /**
      * Array of nullable properties. Used for (de)serialization
      *
      * @var boolean[]
      */
    protected static array $openAPINullables = [
        'time_unit' => false,
        'period_start' => false,
        'period_end' => false,
        'total_usage' => false,
        'history_truncated' => false,
        'data' => false,
        'col_headers' => false,
        'row_headers' => false
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
        'time_unit' => 'timeUnit',
        'period_start' => 'periodStart',
        'period_end' => 'periodEnd',
        'total_usage' => 'totalUsage',
        'history_truncated' => 'historyTruncated',
        'data' => 'data',
        'col_headers' => 'colHeaders',
        'row_headers' => 'rowHeaders'
    ];

    /**
     * Array of attributes to setter functions (for deserialization of responses)
     *
     * @var string[]
     */
    protected static $setters = [
        'time_unit' => 'setTimeUnit',
        'period_start' => 'setPeriodStart',
        'period_end' => 'setPeriodEnd',
        'total_usage' => 'setTotalUsage',
        'history_truncated' => 'setHistoryTruncated',
        'data' => 'setData',
        'col_headers' => 'setColHeaders',
        'row_headers' => 'setRowHeaders'
    ];

    /**
     * Array of attributes to getter functions (for serialization of requests)
     *
     * @var string[]
     */
    protected static $getters = [
        'time_unit' => 'getTimeUnit',
        'period_start' => 'getPeriodStart',
        'period_end' => 'getPeriodEnd',
        'total_usage' => 'getTotalUsage',
        'history_truncated' => 'getHistoryTruncated',
        'data' => 'getData',
        'col_headers' => 'getColHeaders',
        'row_headers' => 'getRowHeaders'
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
        $this->setIfExists('time_unit', $data ?? [], null);
        $this->setIfExists('period_start', $data ?? [], null);
        $this->setIfExists('period_end', $data ?? [], null);
        $this->setIfExists('total_usage', $data ?? [], null);
        $this->setIfExists('history_truncated', $data ?? [], null);
        $this->setIfExists('data', $data ?? [], null);
        $this->setIfExists('col_headers', $data ?? [], null);
        $this->setIfExists('row_headers', $data ?? [], null);
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
     * Gets time_unit
     *
     * @return string|null
     */
    public function getTimeUnit()
    {
        return $this->container['time_unit'];
    }

    /**
     * Sets time_unit
     *
     * @param string|null $time_unit Time unit is DAY, WEEK or MONTH depending on prior usage
     *
     * @return self
     */
    public function setTimeUnit($time_unit)
    {
        if (is_null($time_unit)) {
            throw new \InvalidArgumentException('non-nullable time_unit cannot be null');
        }
        $this->container['time_unit'] = $time_unit;

        return $this;
    }

    /**
     * Gets period_start
     *
     * @return int|null
     */
    public function getPeriodStart()
    {
        return $this->container['period_start'];
    }

    /**
     * Sets period_start
     *
     * @param int|null $period_start Start datetime of the reporting period
     *
     * @return self
     */
    public function setPeriodStart($period_start)
    {
        if (is_null($period_start)) {
            throw new \InvalidArgumentException('non-nullable period_start cannot be null');
        }
        $this->container['period_start'] = $period_start;

        return $this;
    }

    /**
     * Gets period_end
     *
     * @return int|null
     */
    public function getPeriodEnd()
    {
        return $this->container['period_end'];
    }

    /**
     * Sets period_end
     *
     * @param int|null $period_end End datetime of the reporting period
     *
     * @return self
     */
    public function setPeriodEnd($period_end)
    {
        if (is_null($period_end)) {
            throw new \InvalidArgumentException('non-nullable period_end cannot be null');
        }
        $this->container['period_end'] = $period_end;

        return $this;
    }

    /**
     * Gets total_usage
     *
     * @return int|null
     */
    public function getTotalUsage()
    {
        return $this->container['total_usage'];
    }

    /**
     * Sets total_usage
     *
     * @param int|null $total_usage Total usage in the current period
     *
     * @return self
     */
    public function setTotalUsage($total_usage)
    {
        if (is_null($total_usage)) {
            throw new \InvalidArgumentException('non-nullable total_usage cannot be null');
        }
        $this->container['total_usage'] = $total_usage;

        return $this;
    }

    /**
     * Gets history_truncated
     *
     * @return bool|null
     */
    public function getHistoryTruncated()
    {
        return $this->container['history_truncated'];
    }

    /**
     * Sets history_truncated
     *
     * @param bool|null $history_truncated If the history was truncaded due to data limit
     *
     * @return self
     */
    public function setHistoryTruncated($history_truncated)
    {
        if (is_null($history_truncated)) {
            throw new \InvalidArgumentException('non-nullable history_truncated cannot be null');
        }
        $this->container['history_truncated'] = $history_truncated;

        return $this;
    }

    /**
     * Gets data
     *
     * @return int[][]|null
     */
    public function getData()
    {
        return $this->container['data'];
    }

    /**
     * Sets data
     *
     * @param int[][]|null $data Data points : usage per DAY, WEEK or MONTH and per apiService
     *
     * @return self
     */
    public function setData($data)
    {
        if (is_null($data)) {
            throw new \InvalidArgumentException('non-nullable data cannot be null');
        }
        $this->container['data'] = $data;

        return $this;
    }

    /**
     * Gets col_headers
     *
     * @return string[]|null
     */
    public function getColHeaders()
    {
        return $this->container['col_headers'];
    }

    /**
     * Sets col_headers
     *
     * @param string[]|null $col_headers apiServices as column headers
     *
     * @return self
     */
    public function setColHeaders($col_headers)
    {
        if (is_null($col_headers)) {
            throw new \InvalidArgumentException('non-nullable col_headers cannot be null');
        }
        $this->container['col_headers'] = $col_headers;

        return $this;
    }

    /**
     * Gets row_headers
     *
     * @return string[]|null
     */
    public function getRowHeaders()
    {
        return $this->container['row_headers'];
    }

    /**
     * Sets row_headers
     *
     * @param string[]|null $row_headers dates as row headers
     *
     * @return self
     */
    public function setRowHeaders($row_headers)
    {
        if (is_null($row_headers)) {
            throw new \InvalidArgumentException('non-nullable row_headers cannot be null');
        }
        $this->container['row_headers'] = $row_headers;

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


